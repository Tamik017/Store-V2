using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Order
    {
        public int Заказ_ID { get; set; }
        public DateTime Дата_заказа { get; set; }
        public int Клиент_ID { get; set; }
        public int Оценка_ID { get; set; }
        public int Пункт_выдачи_ID { get; set; }
    }
}
