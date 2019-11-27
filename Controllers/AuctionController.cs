using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auction_site.Models;
using auction_site.Services;
using auction_site.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace auction_site.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        private static readonly User Bob = new User()
        {
            UserId = Guid.NewGuid(),
            FirstName = "Bob",
            LastName = "Smith"
        };
        private static readonly User Sally = new User()
        {
            UserId = Guid.NewGuid(),
            FirstName = "Sally",
            LastName = "Kim"
        };
        private static readonly User Rachel = new User()
        {
            UserId = Guid.NewGuid(),
            FirstName = "Rachel",
            LastName = "Parks"
        };
        readonly List<AuctionItem> AuctionItems = new List<AuctionItem>()
        {
            new AuctionItem()
            {
                ItemId = 1,
                OwnerId = Bob.UserId,
                Owner = Bob,
                Name = "Used Car",
                Description = "Blahblahblah",
                StartPrice = 1000,
                BuyItNow = 10000,
                HighestBidder = null,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(7)
            },
            new AuctionItem()
            {
                ItemId = 2,
                OwnerId = Sally.UserId,
                Owner = Sally,
                Name = "Couch",
                Description = "Used Couch",
                StartPrice = 100,
                BuyItNow = 500,
                HighestBidder = null,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(7)
            },new AuctionItem()
            {
                ItemId = 3,
                OwnerId = Rachel.UserId,
                Owner = Rachel,
                Name = "TV",
                Description = "Used TV",
                StartPrice = 150,
                CurrentBid = 200,
                BuyItNow = 500,
                HighestBidder = Bob,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(7)
            },
        };

        private readonly IBidService BidService;
        public AuctionController(IBidService bidService)
        {
            this.BidService = bidService;
        }

        [HttpGet]
        public List<AuctionItem> Get()
        {
            return AuctionItems;
        }

        [HttpPost]
        public async Task<IActionResult> PostBid(Bid bid)
        {
            try
            {
                await BidService.CreateBidAsync(bid).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
