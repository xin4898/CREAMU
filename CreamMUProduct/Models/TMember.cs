using System;
using System.Collections.Generic;

namespace CreamMUProduct.Models
{
    public partial class TMember
    {
        public TMember()
        {
            TTrackingLists = new HashSet<TTrackingList>();
        }

        public int MemberId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<TTrackingList> TTrackingLists { get; set; }
    }
}
