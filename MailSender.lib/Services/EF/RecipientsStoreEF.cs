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
    public class RecipientsStoreEF : IRecipientsStore
    {
        private readonly MailSenderDBContext _db;

        public RecipientsStoreEF(MailSenderDBContext db)
        {
            _db = db;
        }

        public int Create(Recipient item)
        {
            _db.Recipients.Add(item);
            SaveChanges();
            return item.Id;

        }

        public void Edit(int id, Recipient item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));
            var db_item = GetById(item.Id);
            db_item.Name = item.Name;
            db_item.Address = item.Address;
            SaveChanges();

        }

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();

        public Recipient GetById(int id) => _db.Recipients.FirstOrDefault(r => r.Id == id);

        public Recipient Remove(int id)
        {
            var db_item = GetById(id);
            if(db_item is null) return null;
            _db.Recipients.Remove(db_item);
            SaveChanges();
            return db_item;

        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
