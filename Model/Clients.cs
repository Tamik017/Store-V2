using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    [Table("Клиенты")]
    public class Clients
    {
        [Key]
        public int Клиент_ID { get; set; }
        public string ФИО {  get; set; }
        public string Email { get; set; }
    }
}
