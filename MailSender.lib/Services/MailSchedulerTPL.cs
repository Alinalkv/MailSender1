using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class MailSchedulerTPL
    {
        private ISchedulerTaskStore _TaskStore;
        private volatile CancellationTokenSource _TaskCanceliation;

        public MailSchedulerTPL(ISchedulerTaskStore TaskStore)
        {
            _TaskStore = TaskStore;
        }

        public async Task StartAsync()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _TaskCanceliation, cancellation)?.Cancel();


            var firstTask = _TaskStore.GetAll()
                .Where(task => task.Date > DateTime.Now)
                .OrderBy(task => task.Date)
                .FirstOrDefault();
            if (firstTask is null) return;
            WaitTaskAsync(firstTask, cancellation.Token);
        }

        private async void WaitTaskAsync(SchedulerTask task, CancellationToken token)
        {
            var taskTime = task.Date;
            var delta = taskTime.Subtract(DateTime.Now);
            await Task.Delay(delta, token).ConfigureAwait(false);
            await ExecuteTaskAsync(task, token);
            _TaskStore.Remove(task.Id);
            await StartAsync();
        }

        private async Task ExecuteTaskAsync(SchedulerTask task, CancellationToken token)
        {
            throw new NotImplementedException();
            //Test
        }
    }
}
