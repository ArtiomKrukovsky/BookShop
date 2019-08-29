using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Domain.Interfaces;
using WebProject.Domain.Model;
using WebProject.Domain.Repository;
using WebProject.Domain.UOW;

namespace WebProject.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IRepository<Card>>().To<GenericRepository<Card>>();
            Bind<IRepository<City>>().To<GenericRepository<City>>();
            Bind<IRepository<Country>>().To<GenericRepository<Country>>();
            Bind<IRepository<User>>().To<GenericRepository<User>>();
            Bind<IRepository<Seller>>().To<GenericRepository<Seller>>();
            Bind<IRepository<Product>>().To<GenericRepository<Product>>();
            Bind<IRepository<PurchaseInfo>>().To<GenericRepository<PurchaseInfo>>();
            Bind<IRepository<Order>>().To<GenericRepository<Order>>();
        }
    }
}