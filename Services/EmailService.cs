using auction_site.Models;
using auction_site.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auction_site.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(User user)
        {
            //Integrate SendGrid to send to users
        }
    }
}
