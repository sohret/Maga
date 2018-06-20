namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {

        public Product()
        {
            ProductProperty = new HashSet<ProductProperty>();
            ShopProduct = new HashSet<ShopProduct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public long ID { get; set; }

        public long MID { get; set; }

        [Display(Name = "CategoryID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int CategoryID { get; set; }

        [Display(Name = "BrandID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int BrandID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Product_Name", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Name { get; set; }

        [Display(Name = "Product_Rating", ResourceType = typeof(Resources.FieldDisplayText))]
        public double? Rating { get; set; }

        [Display(Name = "Product_VoteCount", ResourceType = typeof(Resources.FieldDisplayText))]
        public int VoteCount { get; set; }

        [Display(Name = "Product_FavoriteCount", ResourceType = typeof(Resources.FieldDisplayText))]
        public int FavoriteCount { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }


        public virtual ICollection<ProductProperty> ProductProperty { get; set; }


        public virtual ICollection<ShopProduct> ShopProduct { get; set; }
    }
}
