using System;
using System.Collections.Generic;

namespace CreamMUProduct.Models
{
    public partial class ProductComment
    {
        public int CommentId { get; set; }
        public int? MemberId { get; set; }
        public string? Comment { get; set; }
        public string? Date { get; set; }
        public int? ProductId { get; set; }
        public int? Stars { get; set; }
        public string? Image { get; set; }
    }
}
