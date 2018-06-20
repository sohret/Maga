namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropertyGroup")]
    public partial class PropertyGroup
    {

        public PropertyGroup()
        {
            PropertyGroupTranslate = new HashSet<PropertyGroupTranslate>();
            ProductProperty = new HashSet<ProductProperty>();
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


        public virtual ICollection<PropertyGroupTranslate> PropertyGroupTranslate { get; set; }
        public virtual ICollection<ProductProperty> ProductProperty { get; set; }
    }
}
