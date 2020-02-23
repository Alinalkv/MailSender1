using MailSender.lib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class SchedulerTask : Entity
    {
        public DateTime Date { get; set; }

        public Sender Sender { get; set; }

        public MailingList MailingList { get; set; }

        public Server Server { get; set; }

        public Mail Mail { get; set; }
    }
}
