namespace FPTBookS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int ID { get; set; }

        public int? OrderID { get; set; }

        public int? ProductID { get; set; }

        public decimal? UnitPriceSale { get; set; }

        public int? QuantitySale { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
