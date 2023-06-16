using System;
using System.Collections.Generic;

namespace CreamMUProduct.Models
{
    public partial class TPType
    {
        public TPType()
        {
            TProducts = new HashSet<TProduct>();
        }

        public int PTypeId { get; set; }
        public string? TypeDescript { get; set; }

        public virtual ICollection<TProduct> TProducts { get; set; }
    }
}
