using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Store.Model
{
    [Table("Поставщики")]
    public class Suppliers
    {
        [Key]
        public int Поставщик_ID { get; set;}

        //[Column]
        public string Название { get; set;}

        //[Column]
        public double Рейтинг {  get; set;}
    }
}
