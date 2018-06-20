namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("v_ScannedProduct")]
    public partial class ViewScannedProduct
    {
        [Key]
        public long ID { get; set; }
        public long MID { get; set; }
        public string content { get; set; }
    }
}
