using System;
using System.Collections.Generic;

namespace m0611.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? EmailId { get; set; }
        public string? Address { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime JoinDate { get; set; }
        public string? Gender { get; set; }
    }
}
