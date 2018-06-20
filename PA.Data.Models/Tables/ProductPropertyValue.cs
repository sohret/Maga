namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPropertyValue")]
    public partial class ProductPropertyValue
    {

        public ProductPropertyValue()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "ProductPropertyID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ProductPropertyID { get; set; }

        [Display(Name = "ValueID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ValueID { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

        public virtual ProductProperty ProductProperty { get; set; }
        public virtual PropertyValue PropertyValue { get; set; }

    }
}
