using System;
using System.Collections.Generic;

#nullable disable

namespace Booking.Models
{
    public partial class RefreshToken
    {
        public int TokenId { get; set; }
        public string Token { get; set; }
        public string RefreshedToken { get; set; }
        public int? UserId { get; set; }

        public virtual Login User { get; set; }
    }
}
