using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using NoIIS.AutoRun;
using NoIIS.Infrastructure;
using NoIIS.ScheduleTimer;

namespace NoIIS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Format("======程序启动 v{0}======",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version));
           
            //#region 注册开机启动
            //try
            //{
            //    var programPath = Environment.CurrentDirectory + "\\NoIIS.exe";
            //    //需要管理员权限
            //    AutoRunHelper.SetAutoRun(programPath, true);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //#endregion

        

            //#region 定时执行的任务
            ////定时器1
            ////ScheTime.Main1();

            ////定时器框架
            //QuartzTimer quartzTimer = new QuartzTimer();
            //quartzTimer.Exec();

            //#endregion

            //#region 开启WebApi服务

            //string weburl = ConfigurationManager.AppSettings["WebUrl"];
            //Console.WriteLine("server running on {0}", weburl);
            ////注册Api服务的地址
            //Console.WriteLine(weburl + "/api/Products");
            //WebApp.Start<Startup>(weburl);

            ////using (WebApp.Start<Startup>(weburl))
            ////{
            ////    Console.WriteLine("server running on {0}", weburl);
            ////    Console.WriteLine(weburl + "/api/Products");
            ////    Console.ReadLine();
            ////}

            //#endregion


            #region 数据库
            SQLiteHelper _sqLiteHelper = new SQLiteHelper();
            if (!File.Exists("MyDb.sqlite"))
            {
                
                SQLiteHelper.CreateDB("MyDb.sqlite");
                SQLiteHelper.SetConnectionString("MyDb.sqlite","password01!",3);
                string logTable = @"DROP TABLE IF EXISTS T_Sys_Log;
CREATE TABLE T_Sys_Log (
ID  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
Content  TEXT,
LogType  INTEGER,
CreateDate  TEXT
);";
                _sqLiteHelper.CreateTable(logTable);

                string sql = "insert into T_Sys_Log(Content,LogType,CreateDate) values('创建数据库,表',1,datetime('now'))";
                _sqLiteHelper.ExecuteNonQuery(sql);
            }
            else
            {
                SQLiteHelper.SetConnectionString("MyDb.sqlite", "password01!", 3);
                var dt = _sqLiteHelper.ExecuteQuery("select * from T_Sys_Log");
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["Content"]);
                    }
                }
            }
            //
            Console.Read();
            
            #endregion
        }
    }
}
