using auction_site.Models;
using auction_site.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace auction_site.Services
{
    public class BidService : BaseService, IBidService
    {
        private readonly AuctionDbContext _Context;
        public BidService(AuctionDbContext context)
            : base(context)
        {
            this._Context = context;
        }
        public async Task<bool> CreateBidAsync(Bid bid)
        {
            try
            {
                // SQL script to post bid to cetain item would go here
                // Transaction would have to be succesful before sending back OK
                await this._Context.AddAsync(bid).ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }

    }
}