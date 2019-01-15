using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Esint.CodeBuilder.Forms;
using Esint.CodeBuilder.Public;
using Esint.CodeBuilder.BLL;
using System.Threading;
//using Esint.CodeBuilder.CheckLog;

namespace CodeBuilder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string regCode = XMLHelper.GetNode(Application.StartupPath + "\\Config\\SysConfig.xml", "RegCode").InnerText;
            Welcome w = new Welcome();
            w.Show();
            w.Refresh();
         //  Thread.Sleep(500);
           

            //if (CheckRegStatus(regCode,w))
                Application.Run(new frm_Main(w));
           // w.Close();
        } 
        
        public static bool CheckRegStatus(string regCode,Welcome w)
        {
            Int64 sVol = GetVol.GetVolOf("C"); //函数GetVolOf()的调用方法 
            
             if (!SecurityBLL.verifyMd5Hash(Convert.ToString(sVol * 3 + 2011),regCode))
             {
                 InputRegCode regform = new InputRegCode();
                 w.Close();
                 regform.ShowDialog();
                 return false;
             }
             return true;
        }
    }
}
