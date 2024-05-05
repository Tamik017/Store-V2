using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    [Table("Категории")]
    public class Categories
    {
        [Key]
        public int Категория_ID { get; set; }
        public string Название { get; set; }
    }
}
