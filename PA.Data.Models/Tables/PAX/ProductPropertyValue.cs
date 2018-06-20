namespace PA.Data.Models.PAX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPropertyValue")]
    public partial class ProductPropertyValue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int ProductPropertyID { get; set; }

        public int ValueID { get; set; }

        public long ProductID { get; set; }

        public int PropertyID { get; set; }

        public int? GroupID { get; set; }

    }
}
