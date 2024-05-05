using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    [Table("Элементы_заказа")]
    public  class OrderElements
    {
        [Key]
        public int Элементы_заказа_ID { get; set; }
        public int Количесвто {  get; set; }
        public int Заказ_ID {  get; set; }
        [ForeignKey(nameof(Заказ_ID))]
        public Orders Заказ {  get; set; }
        
        public int Товар_ID { get; set; }
        [ForeignKey(nameof(Товар_ID))]
        public Products Товар { get; set; }
    }
}
