namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {

        public Category()
        {
            //Category1 = new HashSet<Category>();
            CategoryTranslate = new HashSet<CategoryTranslate>();
            Product = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int OrderNo { get; set; }

        public int? FirstPageOrderNo { get; set; }

        public bool IsActive { get; set; }

        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InsertDate { get; set; }


        //public virtual ICollection<Category> Category1 { get; set; }

        //public virtual Category Category2 { get; set; }


        public virtual ICollection<CategoryTranslate> CategoryTranslate { get; set; }


        public virtual ICollection<Product> Product { get; set; }
    }
}
