using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    [Table("Заказы")]
    public class Orders
    {
        [Key]
        public int Заказ_ID { get; set; }
        public DateTime Дата_заказа { get; set; }
        //public int Клиент_ID { get; set; }
        //public int Оценка_Id { get; set; }
    }
}
