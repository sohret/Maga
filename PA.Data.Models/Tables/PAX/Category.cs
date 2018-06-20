namespace PA.Data.Models.PAX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }

        public int ParentID { get; set; }

        public bool IsLastLevel { get; set; }

        public int OrderNo { get; set; }

        public int? FirstPageOrderNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsMain { get; set; }
    }
}
