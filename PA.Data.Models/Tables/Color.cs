namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Color")]
    public partial class Color
    {
        public Color()
        {
            ColorTranslate = new HashSet<ColorTranslate>();
            ShopProduct = new HashSet<ShopProduct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Color_HexCode", ResourceType = typeof(Resources.FieldDisplayText))]
        [StringLength(7)]
        public string HexCode { get; set; }

        [Display(Name = "OrderNo", ResourceType = typeof(Resources.FieldDisplayText))]
        public int OrderNo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }


        public virtual ICollection<ColorTranslate> ColorTranslate { get; set; }
        public virtual ICollection<ShopProduct> ShopProduct { get; set; }
    }
}
