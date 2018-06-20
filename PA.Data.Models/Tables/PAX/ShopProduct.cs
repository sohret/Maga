namespace PA.Data.Models.PAX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopProduct")]
    public partial class ShopProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int ShopID { get; set; }

        public long ProductID { get; set; }

        public int? ColorID { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(300)]
        public string URL { get; set; }
    }
}
