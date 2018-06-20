namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Crawler")]
    public partial class Crawler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ShopID { get; set; }
        public int? CategoryID { get; set; }
        public int OrderNo { get; set; }

        public bool IsPriceWithPenny { get; set; }
        public string Url { get; set; }
        public string ProductXpath { get; set; }
        public string TitleXpath { get; set; }
        public string UrlXpath { get; set; }
        public string PriceXpath { get; set; }
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "InsertDate", ResourceType = typeof(Resources.FieldDisplayText))]
        public DateTime InsertDate { get; set; }

    }
}
