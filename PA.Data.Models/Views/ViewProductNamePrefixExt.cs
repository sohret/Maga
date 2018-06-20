namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("v_ProductNamePrefix_Ext")]
    public partial class ViewProductNamePrefixExt
    {
        [Key]
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public int PrefixID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime InsertDate { get; set; }
        public int LangCount { get; set; }
    }
}
