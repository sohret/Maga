namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductNamePrefixTranslate")]
    public partial class ProductNamePrefixTranslate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "ProductID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int PrefixID { get; set; }

        [Display(Name = "LanguageID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int LanguageID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Product_Name", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

    }
}
