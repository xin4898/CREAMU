using System;
using System.Collections.Generic;

namespace CreamMUProduct.Models
{
    public partial class TEmployee
    {
        public TEmployee()
        {
            TProducts = new HashSet<TProduct>();
        }

        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }

        public virtual ICollection<TProduct> TProducts { get; set; }
    }
}
