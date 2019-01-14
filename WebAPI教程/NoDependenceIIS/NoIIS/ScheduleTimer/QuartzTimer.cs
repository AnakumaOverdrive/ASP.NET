using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace NoIIS.ScheduleTimer
{
    public class QuartzTimer
    {
        public void Exec()
        {
            string exp = (string)CronExpression.CreateInstance()
                .Seconds(t => t.Loop(0,5))
                .Minutes(t => t.Any())
                .Hours(t => t.Any())
                .DayofMonth(t => t.Any())
                .Month(t => t.Any())
                .DayofWeek(t => t.UnDefine()).ToString();

            Console.WriteLine(exp);

            ISchedulerFactory sf = new Quartz.Impl.StdSchedulerFactory();
            IScheduler sched = sf.GetScheduler();
            sched.Start();
            IJobDetail job = JobBuilder.Create<DefaultJob>().WithIdentity("myJob", "group1").Build();
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("myJobTrigger", "group1").WithCronSchedule(exp).StartNow().Build();
            sched.ScheduleJob(job, trigger);

        }
    }
}
