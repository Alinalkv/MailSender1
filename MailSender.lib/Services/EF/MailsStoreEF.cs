using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.EF
{
    public class MailsStoreEF : StoreEF<Mail>, IMailStore
    {
        public MailsStoreEF(MailSenderDBContext db) : base(db)
        {
        }

        public override void Edit(int id, Mail item)
        {
            var db_item = GetById(id);
            if (db_item == null) return;
            db_item.Subject = item.Subject;
            db_item.Body = item.Body;
        }
    }
}
