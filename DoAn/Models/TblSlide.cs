using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblSlide
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? Sort { get; set; }
        public string? Link { get; set; }
        public bool? Status { get; set; }
    }
}
