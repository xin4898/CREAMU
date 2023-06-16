using System;
using System.Collections.Generic;

namespace m0611.Models
{
    public partial class CombineDetail
    {
        public int CombineId { get; set; }
        public string? Chead { get; set; }
        public string? Cbody { get; set; }
        public string? Clhand { get; set; }
        public string? Crhand { get; set; }
        public string? Clfoot { get; set; }
        public string? Crfoot { get; set; }
        public int SubTotal { get; set; }
        public double TotalPrice { get; set; }
    }
}
