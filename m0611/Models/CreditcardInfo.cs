using System;
using System.Collections.Generic;

namespace m0611.Models
{
    public partial class CreditcardInfo
    {
        public int CreditCardId { get; set; }
        public int? MemberId { get; set; }
        public string CardholderName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public string Cvv { get; set; } = null!;
        public string CardType { get; set; } = null!;
        public bool IsDefault { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Notes { get; set; }
    }
}
