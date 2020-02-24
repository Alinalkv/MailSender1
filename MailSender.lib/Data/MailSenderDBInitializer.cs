using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class MailSenderDBInitializer
    {

        private readonly MailSenderDBContext _db;

        public MailSenderDBInitializer(MailSenderDBContext db)
        {
            _db = db;
        }

        public async Task InitializeAsync()
        {
            _db.Database.CreateIfNotExists();

            await SeedAsync(_db.Mails);
            await SeedAsync(_db.Senders);
            await SeedAsync(_db.Servers);
            await SeedAsync(_db.Recipients);

            if (!await _db.MailingLists.AnyAsync())
            {
                _db.MailingLists.Add(new MailingList
                {
                    Name = "Mail list",
                    Recipients = await _db.Recipients.OrderBy(r => r.Id).Take(5).ToArrayAsync()

                });
                await _db.SaveChangesAsync();
            }

            if (!await _db.SchedulerTasks.AnyAsync())
            {
                _db.SchedulerTasks.Add(new SchedulerTask
                {
                    Date = DateTime.Now.AddDays(10),
                    Server = await _db.Servers.FirstOrDefaultAsync(),
                    MailingList = await _db.MailingLists.FirstOrDefaultAsync(),
                    Sender = await _db.Senders.FirstOrDefaultAsync(),
                     Mail = await _db.Mails.FirstOrDefaultAsync()
                });
                await _db.SaveChangesAsync();
            }
        }

        private async Task SeedAsync(DbSet<Mail> Mails)
        {
            if (await Mails.AnyAsync()) return;

            for (int i = 0; i < 10; i++)
            {
                Mails.Add(new Mail { Subject = $"Тема {i}", Body = $"Текст письма {i}" });
            }

           await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Server> Servers)
        {
            if (await Servers.AnyAsync()) return;

            for (int i = 0; i < 10; i++)
            {
                Servers.Add(new Server { Address = $"smtp.server{i}.ru", Login = $"Логин {i}"
                    , Name = $"Сервер {i}", Password = $"Пароль {i}", Port = i, UserSSL = true});
            }
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Sender> Senders)
        {
            if (await Senders.AnyAsync()) return;

            for (int i = 0; i < 10; i++)
            {
                Senders.Add(new Sender { Name = $"Отправитель {i}", Address = $"sender{i}@server.ru" });
            }
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Recipient> Recipients)
        {
            if (await Recipients.AnyAsync()) return;

            for (int i = 0; i < 10; i++)
            {
                Recipients.Add(new Recipient { Name = $"Получатель {i}", Address = $"recipient{i}@server.ru" });
            }
            await _db.SaveChangesAsync();
        }
    }
}
