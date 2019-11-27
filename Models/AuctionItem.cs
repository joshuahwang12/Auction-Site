using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace auction_site.Models
{
    public class AuctionItem
    { 
        public AuctionItem(int itemId, Guid ownerId, string name, string description, string imageUrl, User highestBidder, decimal startPrice, decimal? currentBid, decimal buyItNow, DateTime startTime, DateTime endTime)
        {
            this.ItemId = itemId;
            this.OwnerId = ownerId;
            this.Name = name;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.HighestBidder = highestBidder;
            this.StartPrice = startPrice;
            this.CurrentBid = currentBid ?? startPrice;
            this.BuyItNow = buyItNow;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
        public AuctionItem() { }
        public int ItemId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public User HighestBidder { get; set; }
        public Stack<Bid> Bids { get;set; }
        public decimal StartPrice { get; set; }
        public decimal? CurrentBid { get; set; }
        public decimal? BuyItNow { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}