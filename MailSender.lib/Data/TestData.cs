using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Service;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
           new Server{Id = 1, Name = "Яндекс", Address = "smtp.yandex.ru", Port = 587, Login = "UserLogin", Password = "UserPassword".Encode() },
           new Server{Id = 2, Name = "Mail.ru", Address = "smtp.mail.ru", Port = 587, Login = "UserLogin", Password = "UserPassword".Encode() },
           new Server{Id = 3, Name = "Gmail", Address = "smtp.gmail.com", Port = 587, Login = "UserLogin", Password = "UserPassword".Encode() },
        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender{Id = 1, Name = "Иванов И.И.", Address = "ivanov@server.ru" },
            new Sender{Id = 2, Name = "Петров П.П.", Address = "petrov@server.ru" },
            new Sender{Id = 3, Name = "Сидоров С.С.", Address = "sidirov@server.ru" },
        };

        public static List<Recipient> Recipients { get; } = new List<Recipient>
        {
            new Recipient{Id = 1, Name = "Камбербетч И.И.", Address = "cucumber@server.ru" },
            new Recipient{Id = 2, Name = "Стоун П.П.", Address = "stone@server.ru" },
            new Recipient{Id = 3, Name = "Уэйн С.С.", Address = "wayne@server.ru" },
        };
    }
}
