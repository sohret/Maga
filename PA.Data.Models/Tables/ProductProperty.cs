namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductProperty")]
    public partial class ProductProperty
    {
        public ProductProperty()
        {
            ProductPropertyValue = new HashSet<ProductPropertyValue>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "ProductID", ResourceType = typeof(Resources.FieldDisplayText))]
        public long ProductID { get; set; }

        [Display(Name = "PropertyID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int PropertyID { get; set; }

        [Display(Name = "GroupID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int? GroupID { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }


        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }
        public virtual PropertyGroup PropertyGroup { get; set; }

        public virtual ICollection<ProductPropertyValue> ProductPropertyValue { get; set; }

    }
}
