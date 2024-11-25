using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblProductComment
    {
        public int CommentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Detail { get; set; }
        public int? ProductId { get; set; }
        public bool? Status { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
