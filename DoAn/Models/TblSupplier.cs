﻿using System;
using System.Collections.Generic;

namespace DoAn.Models
{
    public partial class TblSupplier
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Descriptions { get; set; }
        public string? Image { get; set; }
    }
}
