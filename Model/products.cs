using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class products
    {
        public int Товар_ID { get; set; }
        public int Количество { get; set; }
        public decimal Цена { get; set; }
        public int Рейтинг { get; set; }
        public int Поставщик_ID { get; set; }
        public int Категория_ID { get; set; }
    }
}
