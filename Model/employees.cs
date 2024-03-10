using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Employee
    {
        public int Сотрудник_ID { get; set; }
        public string ФИО { get; set; }
        public decimal Зарплата { get; set; }
        public int Рейтинг { get; set; }
        public int Пункт_выдачи_ID { get; set; }
        public int Оценка_ID { get; set; }
        public string Email { get; set; }
    }
}
