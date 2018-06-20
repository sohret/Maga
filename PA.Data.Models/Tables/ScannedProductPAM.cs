namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScannedProductPAM")]
    public partial class ScannedProductPAM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Required]
        public string Content { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InsertDate { get; set; }



        public string Prefix { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Category { get; set; }

        public int? BrandID { get; set; }
        public int? PrefixID { get; set; }
        public int? CategoryID { get; set; }

        public bool IsPropertyScanned { get; set; }
    }
}
