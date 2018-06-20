namespace PA.Data.Models.PAX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("zSearch")]
    public partial class zSearch
    {
        public int ID { get; set; }

        public int LanguageID { get; set; }

        [Required]
        [StringLength(200)]
        public string URL { get; set; }

        [Required]
        [StringLength(200)]
        public string TEXT { get; set; }

        [Required]
        public string TAGS { get; set; }
    }
}
