using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProjectCore;
using WebProjectCore.PlayerSupport;

namespace WebProjectData
{
    public class WebProjectDbContext : DbContext
    {
        public WebProjectDbContext(DbContextOptions<WebProjectDbContext> options) : base(options)
        {

        }

        public DbSet<PlayerSupport> PlayerSupports { get; set; }
        public DbSet<Champion> Champions { get; set; }
    }
}
