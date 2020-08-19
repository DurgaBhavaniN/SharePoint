using System;
using System.Collections.Generic;

namespace TruyumOnline.Models
{
    public partial class Cart
    {
        public int CartItemId { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public string Active { get; set; }
        public string Category { get; set; }
        public string FreeDelivery { get; set; }
        public int? ItemId { get; set; }
        public virtual Items Item { get; set; }
    }
}
