using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblPostCategory
    {
        public int CateId { get; set; }
        public string? Name { get; set; }
        public string? SeoTitle { get; set; }
        public bool? Status { get; set; }
        public int? Sort { get; set; }
        public int? ParentId { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? MetaDecription { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
