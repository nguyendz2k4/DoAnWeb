using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblInvoice
    {
        public int InvoiceId { get; set; }
        public bool? Status { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
