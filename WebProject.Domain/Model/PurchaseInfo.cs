using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class PurchaseInfo
    {
        public int PurchaseInfoId { get; set; }

        [Display(Name = "Имя получателя")]
        [Required(ErrorMessage = "Введите имя получателя")]
        [StringLength(70,ErrorMessage ="Достигнуто максимальное кол-во символов")]
        public string Name { get; set; }

        [Display(Name = "Страна")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [Display(Name = "Улица, дом, квартира")]
        [Required(ErrorMessage = "Введите улицу, дом и квартиру")]
        [StringLength(70, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public string Adress { get; set; }

        [Display(Name = "Край, область, регион")]
        [Required(ErrorMessage = "Введите край, область и регион")]
        [StringLength(70, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public string Area { get; set; }

        [Display(Name = "Город")]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Display(Name = "Почтовый индекс")]
        [Required(ErrorMessage = "Введите ваш почтовый индекс")]
        [Range(10,0, ErrorMessage = "Введите правильный индекс")]
        public int Index { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Введите телефон")]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        public ICollection<Order> Orders { get; set; }

        public PurchaseInfo()
        {
            Orders = new List<Order>();
        }
    }
}
