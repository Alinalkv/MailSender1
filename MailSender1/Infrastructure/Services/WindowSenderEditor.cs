using MailSender.lib.Entities;
using MailSender1.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender1.Infrastructure.Services
{
    class WindowSenderEditor : ISenderEditor
    {
        public void Edit(Sender sender)
        {
            var editor = new SenderEditor(sender);
            if (editor.ShowDialog() != true) return;

            sender.Name = editor.NameValue;
            sender.Address = editor.AddressValue;
        }
    }
}
