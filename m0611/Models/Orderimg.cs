﻿using System;
using System.Collections.Generic;

namespace m0611.Models
{
    public partial class Orderimg
    {
        public int ImgId { get; set; }
        public int? OrderId { get; set; }
        public string? FPath { get; set; }
        public string Notes { get; set; } = null!;
    }
}
