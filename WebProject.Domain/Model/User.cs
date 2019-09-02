using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Model
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Введите имя пользователя")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }
    }
}
