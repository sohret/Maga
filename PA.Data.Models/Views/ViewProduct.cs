namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("v_Product")]
    public partial class ViewProduct
    {
        [Key]
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public int Rating { get; set; }
        public int VoteCount { get; set; }
        public int FavoriteCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
