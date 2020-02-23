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
    public class MailsStoreInMemory : DataStoreInMemory<Mail>, IMailStore
    {
        
        public MailsStoreInMemory() : base(Enumerable.Range(1, 10).Select(i => new Mail { Id = i, Body = $"Текст сообщения {i}", Subject = $"Тема сообщения {i}"}).ToList())
        {

        }
        public override void Edit(int id, Mail mail)
        {
            var db_mail = GetById(id);
            if (db_mail is null) return;
            db_mail.Subject = mail.Subject;
            db_mail.Body = mail.Body;
        }
    }
}
