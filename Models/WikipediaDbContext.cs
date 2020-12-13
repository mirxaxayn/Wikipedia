using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Wikipedia.Models
{
    public class WikipediaDbContext : DbContext
    {
        public WikipediaDbContext():base("WikipediaConnection")
        {
        }

        public DbSet<SearchItem> SearchItems { get; set; }

    }
}