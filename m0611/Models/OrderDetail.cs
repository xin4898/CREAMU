using System;
using System.Collections.Generic;

namespace m0611.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; }
        public double? Discount { get; set; }
        public int Subtotal { get; set; }
        public string? Notes { get; set; }
    }
}
