using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Infrastructure.DataAccessLayer
{
    public class DataBaseContext : DbContext
    {
        private static DataBaseContext _instance;

        public DataBaseContext() : base("Store")
        { }

        public DbSet<Product> Users { get; set; }
        

        public static DataBaseContext GetDbContext()
        {
            if (_instance == null)
            {
                _instance = new DataBaseContext();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }
    }
}
