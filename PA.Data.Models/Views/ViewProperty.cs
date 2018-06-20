namespace PA.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("v_Property")]
    public partial class ViewProperty
    {
        [Key]
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public int PropertyID { get; set; }
        public int ValueTypeID { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string Comment { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
