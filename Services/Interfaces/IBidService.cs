using auction_site.Models;
using System.Threading.Tasks;

namespace auction_site.Services.Interfaces
{
    public interface IBidService : IService
    {
        Task<bool> CreateBidAsync(Bid bid);
    }
}