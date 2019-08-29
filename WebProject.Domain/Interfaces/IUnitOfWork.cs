using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain.Model;

namespace WebProject.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Card> Cards { get; }
        IRepository<City> Cities { get; }
        IRepository<Country> Countries { get; }
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
        IRepository<PurchaseInfo> PurchaseInfos { get; }
        IRepository<Seller> Sellers { get; }
        IRepository<User> Users { get; }

        void SaveChanges();
    }
}
