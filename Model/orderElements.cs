using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class OrderElements
    {
        public int Элемент_заказа_ID { get; set; }
        public int Количество { get; set; }
        public int Заказ_ID { get; set; }
        public int Товар_ID { get; set; }
    }
}