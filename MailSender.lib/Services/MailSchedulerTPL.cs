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
    public class MailSchedulerTPL : IMailScheduler
    {
        private readonly ISchedulerTaskStore _TaskStore;
        private volatile CancellationTokenSource _TaskCanceliation;
        private readonly IMailSenderService _MailSenderService;

        public MailSchedulerTPL(ISchedulerTaskStore TaskStore, IMailSenderService MailSenderService)
        {
            _TaskStore = TaskStore;
            _MailSenderService = MailSenderService;
        }

        public void Start()
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
            token.ThrowIfCancellationRequested();
            var taskTime = task.Date;
            var delta = taskTime.Subtract(DateTime.Now);

            if(delta.TotalSeconds > 0)
                await Task.Delay(delta, token).ConfigureAwait(false);

            token.ThrowIfCancellationRequested();
            await ExecuteTaskAsync(task, token);
            _TaskStore.Remove(task.Id);
            await Task.Run((Action) Start, token);
        }

        private async Task ExecuteTaskAsync(SchedulerTask task, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            var sender = _MailSenderService.GetSender(task.Server);
            await sender.SendAsync(task.Mail, task.Sender, task.MailingList.Recipients, token);
        }
    }
}
