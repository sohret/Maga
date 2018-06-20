namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductNamePrefix")]
    public partial class ProductNamePrefix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(Resources.FieldDisplayText))]
        public int ID { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.FieldDisplayText))]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

    }
}
