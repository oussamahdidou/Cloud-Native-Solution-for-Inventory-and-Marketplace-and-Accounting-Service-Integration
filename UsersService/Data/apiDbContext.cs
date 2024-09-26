using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersService.Model;

namespace UsersService.Data
{
    public class apiDbContext : IdentityDbContext<AppUser>
    {
        public apiDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }


    }
}