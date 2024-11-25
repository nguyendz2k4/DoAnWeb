using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblOrder
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Satus { get; set; }
        public bool? Delivered { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? CustumerId { get; set; }
        public int? Discount { get; set; }
    }
}
