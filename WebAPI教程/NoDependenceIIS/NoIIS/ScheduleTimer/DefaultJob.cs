using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace NoIIS.ScheduleTimer
{
    [DisallowConcurrentExecution]
    public class DefaultJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Show();
            Console.WriteLine("{0}执行完成啦.", DateTime.Now);
        }

        public async void Show()
        {
            Console.WriteLine("{0}:到达", DateTime.Now);
        }
    }
}
