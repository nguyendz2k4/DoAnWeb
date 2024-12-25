using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblContac
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public bool? Status { get; set; }
        public string? Email { get; set; }
    }
}
