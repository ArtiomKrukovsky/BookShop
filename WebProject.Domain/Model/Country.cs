using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class Country
    {
        public int CountryId { get; set; }

        [Display(Name = "Название страны")]
        [Required(ErrorMessage = "Введите название страны")]
        [StringLength(30, ErrorMessage = "Достигнуто максимальное кол-во символов")]
        public string Name { get; set; }

        public ICollection<PurchaseInfo> PurchaseInfos { get; set; }

        public Country()
        {
            PurchaseInfos = new List<PurchaseInfo>();
        }
    }
}
