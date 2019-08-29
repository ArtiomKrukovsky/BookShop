using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class Card
    {
        public int CardId { get; set; }

        [Display(Name="Номер карты")]
        [Required(ErrorMessage ="Введите номер карты")]
        [Range(16,16,ErrorMessage ="Номер состоит из 16 цифр, введите его правильно")]
        [DataType(DataType.CreditCard)]
        public int CardNumber { get; set; }

        [Display(Name = "СVC код")]
        [Required(ErrorMessage = "Введите СМС код, который находится на обратной стороне карты")]
        [Range(3, 3, ErrorMessage = "СМС код состоит из 3 цифр, введите его правильно")]
        public int CVCCode { get; set; }

        [Display(Name = "Срок действия")]
        [Required(ErrorMessage = "Введите СМС срок действия карты")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Срок состоит 4 цифр")]
        public string DateTo { get; set; }

        public ICollection<User> Users { get; set; }

        public Card()
        {
            Users = new List<User>();
        }
    }
}
