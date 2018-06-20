namespace PA.Data.Models.PAX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdsBoardSiteCategory")]
    public partial class AdsBoardSiteCategory
    {
        [Key]
        public int ID { get; set; }

        public int AdsBoardSiteID { get; set; }

        public int CategoryID { get; set; }

        public string URL { get; set; }
    }
}
