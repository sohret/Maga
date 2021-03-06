namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropertyValueTranslate")]
    public partial class PropertyValueTranslate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "ValueID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ValueID { get; set; }

        [Display(Name = "LanguageID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int LanguageID { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "PropertyValue_Name", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

        public virtual Language Language { get; set; }

        public virtual PropertyValue PropertyValue { get; set; }
    }
}
