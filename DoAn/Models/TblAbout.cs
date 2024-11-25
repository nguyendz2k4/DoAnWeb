using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblAbout
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public bool? Status { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? MetaDecription { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
