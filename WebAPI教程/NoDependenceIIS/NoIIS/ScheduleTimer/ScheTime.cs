
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace NoIIS.ScheduleTimer
{

    public class ScheTime
    {
        //定时器定时执行某一个方法时，可能由于执行的时间长要比间隔的时间长，则这种情况可能导致线程并发性的问题。建议加上Lock
        //private static object LockObject = new Object();
        //private static void CheckUpdatetimer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    // 加锁检查更新锁
        //    lock (LockObject)
        //    {
        //    }
        //}


        private static System.Timers.Timer aTimer;
        static object o = new object();

        public static void Main1()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Enabled = true;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.AutoReset = true;

            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        static object name = 0;
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            lock (o)
            {
                aTimer.Enabled = false;
                //aTimer.Interval = 1000;
                //lock (name)
                {
                    name = Convert.ToInt32(name) + 1;
                    Thread.CurrentThread.Name = name.ToString();
                }
                Console.WriteLine(DateTime.Now.ToString() + "-" + Thread.CurrentThread.Name);
                //Thread.Sleep(1000000);
                Waste();
                aTimer.Enabled = true;
            }

        }

        /// <summary>
        /// 模拟长时间的操作
        /// </summary>
        public static void Waste()
        {
            for (int i = 0; i < Int32.MaxValue; i++)
            {

            }
            //Thread.Sleep(10000);
            Console.WriteLine(DateTime.Now.ToString() + "完成-" + Thread.CurrentThread.Name);
        }

    }
}
