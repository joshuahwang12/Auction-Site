using auction_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auction_site.Services
{
    public abstract class BaseService
    {
        private readonly AuctionDbContext _Context;

        public BaseService(AuctionDbContext context)
        {
            this._Context = context;
        }

    }
}
