namespace PA.Data.Models.PAX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public long ID { get; set; }

        public int CategoryID { get; set; }

        public int BrandID { get; set; }

        public int PrefixID { get; set; }

        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }

        public string Name { get; set; }

    }
}
