using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name = "Название продукта")]
        [Required(ErrorMessage = "Введите название продукта")]
        [StringLength(30, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание")]
        [StringLength(2500, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Введите цену")]
        [Range(0,Int32.MaxValue, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public int Price { get; set; }

        [Display(Name = "Картинка")]
        [Required(ErrorMessage = "Вставьте url картинки")]
        public string ImageUrl { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Product()
        {
            Orders = new List<Order>();
        }
    }
}
