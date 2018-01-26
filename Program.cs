using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleWallet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

#if DEBUG
            Properties.Settings.Default.Reset();
#endif

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var uPrompt = new updatePrompt();
            uPrompt.ShowDialog();

            string _pass = "";
            string _wallet = "";
            if(Properties.Settings.Default.walletPath != "" && System.IO.File.Exists(Properties.Settings.Default.walletPath))
            {
                var pPrompt = new passwordPrompt();
                var pResult = pPrompt.ShowDialog();
                if (pResult != DialogResult.OK)
                {
                    SelectionPrompt sPrompt = new SelectionPrompt();
                    sPrompt.ShowDialog();
                    if (sPrompt.DialogResult != DialogResult.OK)
                        return;
                    else
                    {
                        _pass = sPrompt.walletPassword;
                        _wallet = sPrompt.walletPath;
                    }
                }
                else
                {
                    _pass = pPrompt.walletPassword;
                    _wallet = Properties.Settings.Default.walletPath;
                    pPrompt.Dispose();
                }
            }
            else
            {
                SelectionPrompt sPrompt = new SelectionPrompt();
                sPrompt.ShowDialog();
                if (sPrompt.DialogResult != DialogResult.OK)
                    return;
                else
                {
                    _pass = sPrompt.walletPassword;
                    _wallet = sPrompt.walletPath;
                }
            }

            //var args = new Dictionary<string, object>() { };
            //var testobj = ConnectionManager.rpcRequest("http://127.0.0.1:8070/json_rpc", "getBalance", args);
            //foreach(var item in testobj)
            //{
            //    Console.Write(item.Key + "-" + item.Value);
            //}


            var splash = new Splash(_wallet,_pass);
            Application.Run(splash);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }

    class NoBorderTabControl : TabControl
    {
        private const int TCM_ADJUSTRECT = 0x1328;

        //protected override void WndProc(ref Message m)
        //{
        //    // Hide the tab headers at run-time
        //    if (m.Msg == TCM_ADJUSTRECT && !DesignMode)
        //    {
        //        m.Result = (IntPtr)1;
        //        return;
        //    }

        //    // call the base class implementation
        //    base.WndProc(ref m);
        //}
    }
}
