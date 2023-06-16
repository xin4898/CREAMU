using System;
using System.Collections.Generic;

namespace CreamMUProduct.Models
{
    public partial class TTrackingList
    {
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public DateTime? TrackingDate { get; set; }

        public virtual TMember Member { get; set; } = null!;
    }
}
