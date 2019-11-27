using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace auction_site.Models
{
    public class AuctionDbContext : DbContext
    {
        protected string ConnectionString { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<AuctionItem> AuctionItems { get; set; }

        public AuctionDbContext() { }
        public AuctionDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SqlConnection NewConnection()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }

    }
}