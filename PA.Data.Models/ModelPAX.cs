namespace PA.Data.Models.PAX
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelPAX : DbContext
    {
        public ModelPAX()
            : base("name=ModelPAX")
        {
        }

        public virtual DbSet<AdsBoardSite> AdsBoardSite { get; set; }
        public virtual DbSet<AdsBoardSiteCategory> AdsBoardSiteCategory { get; set; }
        public virtual DbSet<AdsBoardSiteTracker> AdsBoardSiteTracker { get; set; }
        public virtual DbSet<ProductTracker> ProductTracker { get; set; }
        public virtual DbSet<ShopProductTracker> ShopProductTracker { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductNamePrefix> ProductNamePrefix { get; set; }
        public virtual DbSet<ProductProperty> ProductProperty { get; set; }
        public virtual DbSet<ProductPropertyValue> ProductPropertyValue { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyGroup> PropertyGroup { get; set; }
        public virtual DbSet<PropertyValue> PropertyValue { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<ShopProduct> ShopProduct { get; set; }
        public virtual DbSet<zSearch> zSearch { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .Property(e => e.HexCode)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ShopProduct>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<zSearch>()
                .Property(e => e.URL)
                .IsUnicode(false);
        }
    }
}
