namespace PA.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelPA : DbContext
    {
        public ModelPA()
            : base("name=ModelPA")
        {
            Database.SetInitializer<ModelPA>(new NullDatabaseInitializer<ModelPA>());

            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }


        #region Tables

        public virtual DbSet<ProductDefaultProperty> ProductDefaultProperty { get; set; }
        public virtual DbSet<PropertyGroup> PropertyGroup { get; set; }
        public virtual DbSet<PropertyGroupTranslate> PropertyGroupTranslate { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<ColorTranslate> ColorTranslate { get; set; }
        public virtual DbSet<PropertyValue> PropertyValue { get; set; }
        public virtual DbSet<PropertyValueTranslate> PropertyValueTranslate { get; set; }
        public virtual DbSet<ProductNamePrefix> ProductNamePrefix { get; set; }
        public virtual DbSet<ProductNamePrefixTranslate> ProductNamePrefixTranslate { get; set; }
        public virtual DbSet<ScannedProduct> ScannedProduct { get; set; }
        public virtual DbSet<Crawler> Crawler { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryTranslate> CategoryTranslate { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LanguageTranslate> LanguageTranslate { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductProperty> ProductProperty { get; set; }
        public virtual DbSet<ProductPropertyValue> ProductPropertyValue { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyTranslate> PropertyTranslate { get; set; }
        public virtual DbSet<PropertyValueType> PropertyValueType { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<ShopProduct> ShopProduct { get; set; }
        public virtual DbSet<ShopTranslate> ShopTranslate { get; set; }
        //public virtual DbSet<Role> Role { get; set; }
        //public virtual DbSet<Users> Users { get; set; }

        #endregion Tables


        #region Views

        public virtual DbSet<ScannedProductPAM> ScannedProductPAM { get; set; }
        public virtual DbSet<ViewScannedProduct> ViewScannedProduct { get; set; }
        public virtual DbSet<ViewCategory> ViewCategory { get; set; }
        public virtual DbSet<ViewColor> ViewColor { get; set; }
        public virtual DbSet<ViewLanguage> ViewLanguage { get; set; }
        public virtual DbSet<ViewProduct> ViewProduct { get; set; }
        public virtual DbSet<ViewProductNamePrefix> ViewProductNamePrefix { get; set; }
        public virtual DbSet<ViewProperty> ViewProperty { get; set; }
        public virtual DbSet<ViewPropertyGroup> ViewPropertyGroup { get; set; }
        public virtual DbSet<ViewPropertyValue> ViewPropertyValue { get; set; }
        public virtual DbSet<ViewShop> ViewShop { get; set; }


        public virtual DbSet<ViewCategoryExt> ViewCategoryExt { get; set; }
        public virtual DbSet<ViewColorExt> ViewColorExt { get; set; }
        public virtual DbSet<ViewLanguageExt> ViewLanguageExt { get; set; }
        public virtual DbSet<ViewProductExt> ViewProductExt { get; set; }
        public virtual DbSet<ViewProductNamePrefixExt> ViewProductNamePrefixExt { get; set; }
        public virtual DbSet<ViewPropertyExt> ViewPropertyExt { get; set; }
        public virtual DbSet<ViewPropertyGroupExt> ViewPropertyGroupExt { get; set; }
        public virtual DbSet<ViewPropertyValueExt> ViewPropertyValueExt { get; set; }
        public virtual DbSet<ViewShopExt> ViewShopExt { get; set; }
        
        #endregion Views


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            #region Property

            modelBuilder.Entity<PropertyGroup>()
                .HasMany(e => e.PropertyGroupTranslate)
                .WithRequired(e => e.PropertyGroup)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.PropertyTranslate)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.PropertyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.ProductProperty)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.PropertyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropertyValue>()
                .HasMany(e => e.PropertyValueTranslate)
                .WithRequired(e => e.PropertyValue)
                .HasForeignKey(e => e.ValueID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductProperty>()
                .HasMany(e => e.ProductPropertyValue)
                .WithRequired(e => e.ProductProperty)
                .HasForeignKey(e => e.ProductPropertyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropertyValue>()
                .HasMany(e => e.ProductPropertyValue)
                .WithRequired(e => e.PropertyValue)
                .HasForeignKey(e => e.ValueID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropertyValueType>()
                .HasMany(e => e.Property)
                .WithRequired(e => e.PropertyValueType)
                .HasForeignKey(e => e.ValueTypeID)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<PropertyGroup>()
                .HasMany(e => e.ProductProperty)
                .WithOptional(e => e.PropertyGroup)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);

            #endregion Property

            //modelBuilder.Entity<CategoryInCategory>()
            //    .HasMany(e => e.Category1)
            //    .WithOptional(e => e.Category2)
            //    .HasForeignKey(e => e.CategoryParentID);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.ShopProduct)
                .WithOptional(e => e.Color)
                .HasForeignKey(e => e.ColorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.ColorTranslate)
                .WithRequired(e => e.Color)
                .HasForeignKey(e => e.ColorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryTranslate)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.CategoryTranslate)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.LanguageTranslate)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.PropertyTranslate)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.ShopTranslate)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.BrandID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductProperty)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShopProduct)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.ShopProduct)
                .WithRequired(e => e.Shop)
                .HasForeignKey(e => e.ShopID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.ShopTranslate)
                .WithRequired(e => e.Shop)
                .HasForeignKey(e => e.ShopID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<ShopProduct>()
                .Property(e => e.URL)
                .IsUnicode(false);

            //modelBuilder.Entity<Role>()
            //    .HasMany(e => e.Users)
            //    .WithRequired(e => e.Role)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Users>()
            //    .Property(e => e.Username)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Users>()
            //    .Property(e => e.Password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Users>()
            //    .Property(e => e.Mail)
            //    .IsUnicode(false);


        }
    }
}
