using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myproj.Models;

namespace myproj.Models
{
    public class MyprojContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<CentralTbl> CentralTbl { get; set; }

        public MyprojContext(DbContextOptions<MyprojContext> options) : base(options)
        { }

    }
}
