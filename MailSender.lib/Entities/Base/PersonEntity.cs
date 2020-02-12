using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities.Base
{
    public abstract class PersonEntity : NamedEntity
    {
        public string Address { get; set; }
    }
}
