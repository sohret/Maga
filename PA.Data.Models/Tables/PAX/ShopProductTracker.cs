namespace PA.Data.Models.PAX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopProductTracker")]
    public partial class ShopProductTracker
    {
        public ShopProductTracker()
        {
            UserID = 0; // Guest
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public int UserID { get; set; }

        public int ShopProductID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime InsertDate { get; set; }
    }
}
