using System;
using System.Collections.Generic;

namespace m0611.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Descript { get; set; } = null!;
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool ProductStatus { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? EmployeeId { get; set; }
    }
}
