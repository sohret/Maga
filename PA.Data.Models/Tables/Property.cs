namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Property")]
    public partial class Property
    {

        public Property()
        {
            PropertyTranslate = new HashSet<PropertyTranslate>();
            ProductProperty = new HashSet<ProductProperty>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "ValueTypeID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ValueTypeID { get; set; }

        [Display(Name = "OrderNo", ResourceType = typeof(Resources.FieldDisplayText))]
        public int OrderNo { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }


        public virtual PropertyValueType PropertyValueType { get; set; }
        public virtual ICollection<ProductProperty> ProductProperty { get; set; }

        public virtual ICollection<PropertyTranslate> PropertyTranslate { get; set; }
    }
}
