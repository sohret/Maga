namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {

        public Language()
        {
            CategoryTranslate = new HashSet<CategoryTranslate>();
            LanguageTranslate = new HashSet<LanguageTranslate>();
            PropertyTranslate = new HashSet<PropertyTranslate>();
            ShopTranslate = new HashSet<ShopTranslate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Language_Code", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Code { get; set; }

        [Display(Name = "OrderNo", ResourceType = typeof(Resources.FieldDisplayText))]
        public int OrderNo { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }


        public virtual ICollection<CategoryTranslate> CategoryTranslate { get; set; }


        public virtual ICollection<LanguageTranslate> LanguageTranslate { get; set; }


        public virtual ICollection<PropertyTranslate> PropertyTranslate { get; set; }


        public virtual ICollection<ShopTranslate> ShopTranslate { get; set; }
    }
}
