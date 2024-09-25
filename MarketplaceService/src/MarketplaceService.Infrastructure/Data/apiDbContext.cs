using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceService.Infrastructure.Data
{
    public class apiDbContext : DbContext
    {
        public apiDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
    }
}