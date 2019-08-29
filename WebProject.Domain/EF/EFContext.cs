namespace WebProject.Domain.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebProject.Domain.Model;

    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<PurchaseInfo> PurchaseInfos { get; set; }
    }

    public class Init: DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            context.Countries.Add(new Country {CountryId=1, Name="Беларусь" });
            context.Countries.Add(new Country {CountryId=2, Name="Россия" });
            context.Countries.Add(new Country {CountryId=3, Name="Украина" });
            context.Countries.Add(new Country {CountryId=4, Name="Польша" });
            base.Seed(context);
        }
    }

}