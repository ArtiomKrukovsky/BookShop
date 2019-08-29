using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class City
    {
        public int CityId { get; set; }

        [Display(Name = "Название города")]
        [Required(ErrorMessage = "Введите название города")]
        [StringLength(30, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public string Name { get; set; }

        public ICollection<PurchaseInfo> PurchaseInfos { get; set; }

        public City()
        {
            PurchaseInfos = new List<PurchaseInfo>();
        }
    }
}
