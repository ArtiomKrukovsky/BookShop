using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain.EF;
using WebProject.Domain.Interfaces;
using WebProject.Domain.Model;

namespace WebProject.Domain.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        EFContext context = new EFContext();

        public UnitOfWork(IRepository<Card> repositorycard, IRepository<City> repositorycity, IRepository<Country> repositorycountry, IRepository<Order> repositoryorder,
            IRepository<Product> repositoryproduct, IRepository<PurchaseInfo> repositorypurchaseInfo, IRepository<Seller> repositoryseller, IRepository<User> repositoryuser)
        {
            _repositoryCard = repositorycard;
            _repositoryCity = repositorycity;
            _repositoryCountry = repositorycountry;
            _repositoryOrder = repositoryorder;
            _repositoryProduct = repositoryproduct;
            _repositoryPurchaseInfo = repositorypurchaseInfo;
            _repositorySeller = repositoryseller;
            _repositoryUser = repositoryuser;
        }

        private IRepository<Card> _repositoryCard;
        private IRepository<City> _repositoryCity;
        private IRepository<Country> _repositoryCountry;
        private IRepository<Order> _repositoryOrder;
        private IRepository<Product> _repositoryProduct;
        private IRepository<PurchaseInfo> _repositoryPurchaseInfo;
        private IRepository<Seller> _repositorySeller;
        private IRepository<User> _repositoryUser;

        public IRepository<Card> Cards
        {
            get
            {
                return _repositoryCard;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                return _repositoryCity;
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return _repositoryCountry;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return _repositoryOrder;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return _repositoryProduct;
            }
        }

        public IRepository<PurchaseInfo> PurchaseInfos
        {
            get
            {
                return _repositoryPurchaseInfo;
            }
        }

        public IRepository<Seller> Sellers
        {
            get
            {
                return _repositorySeller;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return _repositoryUser;
            }
        }

        public void SaveChanges()
        {
            _repositoryUser.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
