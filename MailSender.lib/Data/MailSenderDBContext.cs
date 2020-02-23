using MailSender.lib.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public class MailSenderDBContext : DbContext
    {
        public DbSet<MailDB> MailDBs { get; set; }
        public DbSet<RecipientDB> RecipientDBs { get; set; }
        public DbSet<SenderDB> SenderDBs { get; set; }
        public DbSet<ServerDB> ServerDBs { get; set; }

        public MailSenderDBContext() : base("name=DefaultConnection")
        {

        }

        public MailSenderDBContext(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
