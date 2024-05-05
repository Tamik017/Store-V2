using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    [Table("Оценка")]
    public class Rating
    {
        [Key]
        public int Оценка_ID { get; set; }
        public string Адресс_Оценки { get; set; }
        public double Оценка_Рейтинг {  get; set; }
    }
}
