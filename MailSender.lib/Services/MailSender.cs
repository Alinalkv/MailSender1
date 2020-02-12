using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MailSender.lib.Services
{

    public class MailSender
    {

        private readonly string _ServerAddress;
        private readonly int _Port;
        private bool _UseSSL;
        private string _UserName;
        private string _Password;


        public MailSender(string ServerAddress, int Port, bool UseSSL, string UserName, string Password)
        {
            _ServerAddress = ServerAddress;
            _Port = Port;
            _UseSSL = UseSSL;
            _UserName = UserName;
            _Password = Password;
        }

        public void Send(string Subject, string Body, string From, string To)
        {
            using (System.Net.Mail.MailMessage msg = new MailMessage(From, To))
            {
                msg.Subject = Subject;
                msg.Body = Body;
                msg.IsBodyHtml = false;

                using (System.Net.Mail.SmtpClient client = new SmtpClient(_ServerAddress, _Port))
                {
                    client.EnableSsl = _UseSSL;
                    client.Credentials = new NetworkCredential(_UserName, _Password);
                    client.Send(msg);
                }

            }
        }
    }

    public class DebugMailSender
    {

        private readonly string _ServerAddress;
        private readonly int _Port;
        private bool _UseSSL;
        private string _UserName;
        private string _Password;


        public DebugMailSender(string ServerAddress, int Port, bool UseSSL, string UserName, string Password)
        {
            _ServerAddress = ServerAddress;
            _Port = Port;
            _UseSSL = UseSSL;
            _UserName = UserName;
            _Password = Password;
        }

        public void Send(string Subject, string Body, string From, string To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]/n{5}:{6}",
                From, To, _ServerAddress, _Port, _UseSSL ? "SSL" : "no SSL", Subject, Body);
        }
    }
}
