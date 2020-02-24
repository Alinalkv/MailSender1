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
    public class ServersStoreEF : StoreEF<Server>, IServerStore
    {
        public ServersStoreEF(MailSenderDBContext db) : base(db)
        {
        }

        public override void Edit(int id, Server item)
        {
            var db_item = GetById(id);
            if (db_item == null) return;
            db_item.Address = item.Address;
            db_item.Login = item.Login;
            db_item.Name = item.Name;
            db_item.Password = item.Password;
            db_item.Port = item.Port;
            db_item.UserSSL = item.UserSSL;
        }
    }
}
