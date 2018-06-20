namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryTranslate")]
    public partial class CategoryTranslate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "CategoryID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int CategoryID { get; set; }

        [Display(Name = "LanguageID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int LanguageID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category_Name", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

        public virtual Category Category { get; set; }

        public virtual Language Language { get; set; }
    }
}
