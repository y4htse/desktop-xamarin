using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TurtleWallet
{
    class ConnectionManager
    {
        public static int rpcID = 0;
        private static JObject _request(string method, Dictionary<string,object> args)
        {
            var builtURL = Properties.Settings.Default.RPCprotocol + "://" + Properties.Settings.Default.RPCdestination + ":" + Properties.Settings.Default.RPCport + Properties.Settings.Default.RPCtrailing;
            var payload = new Dictionary<string, object>()
            {
                { "jsonrpc", "2.0" },
                { "method", method },
                { "params", args },
                { "id", rpcID.ToString() }
            };
            string payloadJSON = JsonConvert.SerializeObject(payload, Formatting.Indented);
            rpcID++;

            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = cli.UploadString(builtURL, payloadJSON);

            var jobj = JObject.Parse(response);
            if (jobj.ContainsKey("error"))
            {
                throw new Exception("Walletd RPC failed with error: " + Convert.ToInt32(jobj["error"]["code"]).ToString() + "  " + jobj["error"]["message"]);
            }
            return (JObject)jobj["result"];
        }

        public static Tuple<bool,string,JObject> request(string method, Dictionary<string, object> args = null)
        {
            if (args == null) args = new Dictionary<string, object>() { };
            try
            {
                var results = _request(method, args);
                return Tuple.Create<bool, string, JObject>(true, "", results);
            }
            catch(Exception e)
            {
                return Tuple.Create<bool,string,JObject>(false, e.Message, null);
            }
        }

        public static Tuple<bool,string, Process> startDaemon(string _wallet, string _pass)
        {
            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var walletdexe = System.IO.Path.Combine(curDir, "walletd.exe");
            if (!System.IO.File.Exists(_wallet))
            {
                return Tuple.Create<bool,string,Process>(false, "Wallet file cannot be found! Must exit!", null);
            }
            bool goodExistingDaemonRunning = false;
            var _procs = Process.GetProcessesByName("walletd");
            if(_procs.Length > 0)
            {
                var _proc_Path = System.IO.Path.GetDirectoryName(_procs[0].MainModule.FileName);
                if (_proc_Path == curDir)
                    goodExistingDaemonRunning = true;
                else
                    _procs[0].Kill();
            }
            if (goodExistingDaemonRunning)
                return Tuple.Create<bool,string,Process>(true,"",_procs[0]);
            else
            {
                Process p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.FileName = walletdexe;
                p.StartInfo.Arguments = "-w \"" + _wallet + "\" -p " + _pass + " --local";
                p.Start();
                System.Threading.Thread.Sleep(1500);
                if (p.HasExited)
                    return Tuple.Create<bool, string, Process>(false, "Unable to keep daemon up!", null);
                return Tuple.Create<bool, string, Process>(true, "", p);
            }


        }

        public static Tuple<bool,JObject> get_live_stats()
        {
            string pool_eu = "http://eu.turtlepool.space:8117/live_stats";
            string pool_us = "https://pool.turtleco.in/api/live_stats";
            string content = "";
            try
            {
                var cli = new DecompressClient();
                cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                content = cli.DownloadString(pool_eu);
            }
            catch (Exception) { }
            if (content == "")
            {
                try
                {
                    var cli = new DecompressClient();
                    cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                    content = cli.DownloadString(pool_us);
                }
                catch (Exception) { }
            }
            if (content == "")
            {
                return Tuple.Create<bool, JObject>(false, null);
            }
            else
            {
                var jobj = JObject.Parse(content);
                return Tuple.Create<bool, JObject>(true, jobj);
            }
        }
    }

    public static class JsonConversionExtensions
    {
        public static IDictionary<string, object> ToDictionary(this JObject json)
        {
            var propertyValuePairs = json.ToObject<Dictionary<string, object>>();
            ProcessJObjectProperties(propertyValuePairs);
            ProcessJArrayProperties(propertyValuePairs);
            return propertyValuePairs;
        }

        private static void ProcessJObjectProperties(IDictionary<string, object> propertyValuePairs)
        {
            var objectPropertyNames = (from property in propertyValuePairs
                                       let propertyName = property.Key
                                       let value = property.Value
                                       where value is JObject
                                       select propertyName).ToList();

            objectPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToDictionary((JObject)propertyValuePairs[propertyName]));
        }

        private static void ProcessJArrayProperties(IDictionary<string, object> propertyValuePairs)
        {
            var arrayPropertyNames = (from property in propertyValuePairs
                                      let propertyName = property.Key
                                      let value = property.Value
                                      where value is JArray
                                      select propertyName).ToList();

            arrayPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToArray((JArray)propertyValuePairs[propertyName]));
        }

        public static object[] ToArray(this JArray array)
        {
            return array.ToObject<object[]>().Select(ProcessArrayEntry).ToArray();
        }

        private static object ProcessArrayEntry(object value)
        {
            if (value is JObject)
            {
                return ToDictionary((JObject)value);
            }
            if (value is JArray)
            {
                return ToArray((JArray)value);
            }
            return value;
        }
    }

    class DecompressClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }
}
