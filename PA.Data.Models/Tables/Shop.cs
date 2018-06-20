namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shop")]
    public partial class Shop
    {

        public Shop()
        {
            ShopProduct = new HashSet<ShopProduct>();
            ShopTranslate = new HashSet<ShopTranslate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Shop_URL", ResourceType = typeof(Resources.FieldDisplayText))]
        public string URL { get; set; }

        [Display(Name = "OrderNo", ResourceType = typeof(Resources.FieldDisplayText))]
        public int OrderNo { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }


        public virtual ICollection<ShopProduct> ShopProduct { get; set; }


        public virtual ICollection<ShopTranslate> ShopTranslate { get; set; }
    }
}
