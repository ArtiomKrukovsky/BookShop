using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class Seller
    {
        public int SellerId { get; set; }

        [Display(Name = "Имя продовца")]
        [Required(ErrorMessage = "Введите имя продовца")]
        [StringLength(70, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public string Name { get; set; }

    }
}
