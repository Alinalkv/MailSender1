using MailSender.lib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Tests.Services.InMemory
{
    [TestClass]
    public class RecipientsStoreInMemoryTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Create_throw_ArgumentsNullException_if_item_is_null()
        {
            var store = new RecipientsStoreInMemory();

            store.Create(null);
        }
    }
}
