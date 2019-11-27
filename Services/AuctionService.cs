using auction_site.Models;
using auction_site.Services.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auction_site.Services
{
    public class AuctionService : BaseService, IAuctionService
    {
        private readonly IEmailService EmailService;
        private readonly AuctionDbContext _Context;

        public AuctionService(AuctionDbContext context, EmailService emailService)
            : base(context)
        {
            this._Context = context;
            this.EmailService = emailService;
        }
        public void ConfirmAuctionWinner (AuctionItem auctionItem)
        {
            if (auctionItem.EndTime <= DateTime.Now)
            {
                this.EmailService.SendEmail(auctionItem.HighestBidder);

            }
        }

        public AuctionItem GetAuctionItem(Bid bid)
        {
            var query = $"Select * from AuctionItems where ItemId = @ItemId";
            using (var connection = _Context.NewConnection())
            {
                var auctionItem = connection.QueryFirstOrDefault<AuctionItem>(query, new { ItemId = bid.ItemId});
                return auctionItem;
            }
        }
       
    }
}
