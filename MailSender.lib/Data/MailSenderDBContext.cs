using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class MailSenderDBContext : DbContext
    {

        public DbSet<Mail> Mails { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<MailingList> MailingLists { get; set; }
        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        [PreferredConstructorAttribute]
        public MailSenderDBContext() : base("name=DefaultConnection")
        {

        }

        public MailSenderDBContext(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
