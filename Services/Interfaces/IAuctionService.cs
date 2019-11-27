using auction_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auction_site.Services.Interfaces
{
    interface IAuctionService : IService
    {
        void ConfirmAuctionWinner(AuctionItem auctionItem);

        AuctionItem GetAuctionItem(Bid bid);
        List<AuctionItem> GetAuctionItems();
    }
}
