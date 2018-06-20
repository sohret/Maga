namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryInCategory")]
    public partial class CategoryInCategory
    {

        public CategoryInCategory()
        {
            //Category1 = new HashSet<CategoryInCategory>();
            //CategoryTranslate = new HashSet<CategoryTranslate>();
            //Product = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public int CategoryParentID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InsertDate { get; set; }

        public bool IsMain { get; set; }


        //public virtual ICollection<CategoryInCategory> Category1 { get; set; }

        //public virtual CategoryInCategory Category2 { get; set; }


        //public virtual ICollection<CategoryTranslate> CategoryTranslate { get; set; }


        //public virtual ICollection<Product> Product { get; set; }
    }
}
