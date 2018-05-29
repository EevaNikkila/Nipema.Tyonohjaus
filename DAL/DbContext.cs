namespace Nipema.Tyonohjaus.EF
{
    using Nipema.Tyonohjaus.Models;
    using System.Data.Entity;

    public class TyonohjausDbContext : DbContext
    {
        // Your context has been configured to use a 'MyDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Tietokanta.Database.MyDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyDbContext' 
        // connection string in the application configuration file.
        public TyonohjausDbContext()
            : base("MyDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TyonohjausDbContext, Nipema.Tyonohjaus.EF.Configuration>("MyDbContext"));
        }

        public virtual DbSet<Ohje> Ohjeet { get; set; }
        public virtual DbSet<Hylatty> Hylatyt { get; set; }
        public virtual DbSet<ProductPropertyDescription> ProductPropertyDescriptions { get; set; }
        public virtual DbSet<ProductPropertyValue> ProductPropertyValues { get; set; }
        public virtual DbSet<LoadedItem> Ripustetut { get; set; }
        public virtual DbSet<TrolleyLocation> TrolleyLocations { get; set; }
        public virtual DbSet<Valmis> Valmiit { get; set; }
        public virtual DbSet<Tyo> Tyojono { get; set; }
        public virtual DbSet<Vari> Varit { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<TyoDescription> TyoDescriptions { get; set; }
        public virtual DbSet<SensorData> SensorData { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}