using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auction_site.Models
{
    public class Bid
    {
        public string Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int ItemId { get; set; }
        public AuctionItem Item { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
