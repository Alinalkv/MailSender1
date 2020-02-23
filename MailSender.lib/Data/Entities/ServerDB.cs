using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.Entities
{
    public class ServerDB
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public bool UserSSL { get; set; } = true;
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
