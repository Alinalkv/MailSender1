using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public class RecipientsManager : IRecipientsManager
    {
        private IRecipientsStore _Store;

        public RecipientsManager(IRecipientsStore Store)
        {
            _Store = Store;
        }

        public IEnumerable<Recipient> GetAll() => _Store.GetAll();

        public void Add(Recipient NewRecipient)
        {

        }

        public void Edit(Recipient Recipient)
        {
            _Store.Edit(Recipient.Id, Recipient);
        }

        public void SaveChanges()
        {
            _Store.SaveChanges();
        }

        public void Delete(Recipient Recipient)
        {

        }
    }
}
