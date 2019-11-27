using auction_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auction_site.Services.Interfaces
{
    interface IEmailService : IService
    {
        void SendEmail(User user);
    }
}
