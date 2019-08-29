using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Введите количество")]
        [Range(0, 10, ErrorMessage = "Достигнуто максимальное кол-во")]
        public int Count { get; set; }
    }
}
