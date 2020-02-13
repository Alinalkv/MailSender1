using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.InMemory
{
    public class SendersStoreInMemory : DataStoreInMemory<Sender>, ISenderStore
    {
        public SendersStoreInMemory() : base(TestData.Senders) { }

        public override void Edit(int id, Sender sender)
        {
            var db_sender = GetById(id);
            if (db_sender is null) return;
            db_sender.Name = sender.Name;
            db_sender.Address = sender.Address;
        }
    }
}
