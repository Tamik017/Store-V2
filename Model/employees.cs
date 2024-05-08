using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    [Table("Сотрудники")]
    public class Employees
    {
        [Key]
        public int Сотрудник_ID { get; set; }
        public string ФИО { get; set; }
        public decimal Зарплата { get; set; }
        public double Рейтинг { get; set; }
        public string Email { get; set; }
        public string PasswordUser { get; set; }
        public string Роль {  get; set; }
        public int Оценка_ID { get; set; }
        [ForeignKey(nameof(Оценка_ID))]
        public Rating Оценка {  get; set; }

    }
}
