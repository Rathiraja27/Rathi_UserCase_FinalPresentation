using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket.Models
{
    public partial class Discount
    {
        public string DiscountCode { get; set; }
        public int Percentage { get; set; }
    }
}
