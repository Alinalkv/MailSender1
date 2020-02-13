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
    public class ServersStoreInMemory : DataStoreInMemory<Server>, IServerStore
    {
        public ServersStoreInMemory() : base(TestData.Servers) { }

        public override void Edit(int id, Server server)
        {
            var db_server = GetById(id);
            if (db_server is null) return;
            db_server.Name = server.Name;
            db_server.Address = server.Address;
            db_server.Port = server.Port;
            db_server.Login = server.Login;
            db_server.Password = server.Password;
        }
    }
}
