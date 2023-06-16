using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace m0611.Models
{
    public partial class PostAddress
    {
        [Key]
        public int AddressId { get; set; }
        public int MemberId { get; set; }
        public string? AddressType { get; set; }
        public string RecipientName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool IsDefault { get; set; }
        public string? Notes { get; set; }
    }
}
