using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    [Table("Товары")]
    public class Products
    {
        [Key]
        public int Товар_ID { get; set; }

        public int Количество {  get; set; }
        public decimal Цена {  get; set; }
        public double Рейтинг {  get; set; }

        public int Поставщик_ID { get; set; }
        [ForeignKey(nameof(Поставщик_ID))]
        public Suppliers Поставщик { get; set; }

        public int Категория_ID { get; set; }
        [ForeignKey(nameof(Категория_ID))]
        public Categories Категория { get; set; }
    }
}
