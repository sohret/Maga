namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropertyGroupTranslate")]
    public partial class PropertyGroupTranslate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "PropertyID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int GroupID { get; set; }

        [Display(Name = "LanguageID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int LanguageID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Property_Name", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

        public virtual Language Language { get; set; }

        public virtual PropertyGroup PropertyGroup { get; set; }
    }
}
