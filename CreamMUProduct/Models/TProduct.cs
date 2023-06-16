using System;
using System.Collections.Generic;

namespace CreamMUProduct.Models
{
    public partial class TProduct
    {
        public int ProductId { get; set; }
        public string? PName { get; set; }
        public int? PTypeId { get; set; }
        public decimal? PPrice { get; set; }
        public int? PInstock { get; set; }
        public string? PStatus { get; set; }
        public string? PDescript { get; set; }
        public string? PReleaseDate { get; set; }
        public int? EmployeeId { get; set; }
        public string PImages { get; set; } = null!;

        public virtual TEmployee? Employee { get; set; }
        public virtual TPType? PType { get; set; }
    }
}
