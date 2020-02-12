using MailSender.lib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    /// <summary>
    /// Почтовый сервер
    /// </summary>
    public class Server : NamedEntity
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UserSSL { get; set; } = true;
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
