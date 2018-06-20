namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("v_Color_Ext")]
    public partial class ViewColorExt
    {
        [Key]
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public int ColorID { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string HexCode { get; set; }
        public DateTime InsertDate { get; set; }
        public int LangCount { get; set; }
    }
}
