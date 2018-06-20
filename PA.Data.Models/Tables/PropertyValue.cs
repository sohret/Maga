namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropertyValue")]
    public partial class PropertyValue
    {

        public PropertyValue()
        {
            ProductPropertyValue = new HashSet<ProductPropertyValue>();
            PropertyValueTranslate = new HashSet<PropertyValueTranslate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "OrderNo", ResourceType = typeof(Resources.FieldDisplayText))]
        public int OrderNo { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }


        public virtual ICollection<ProductPropertyValue> ProductPropertyValue { get; set; }

        public virtual ICollection<PropertyValueTranslate> PropertyValueTranslate { get; set; }
    }
}
