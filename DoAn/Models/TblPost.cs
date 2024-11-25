using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblPost
    {
        public int PostId { get; set; }
        public string? Name { get; set; }
        public string? SeoTitle { get; set; }
        public bool? Status { get; set; }
        public string? Image { get; set; }
        public string? Decription { get; set; }
        public string? Detail { get; set; }
        public int? ViewCount { get; set; }
        public int? CateId { get; set; }
        public string? Tags { get; set; }
        public int? UpdateBy { get; set; }
        public int? BraindId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? MetaDecription { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
