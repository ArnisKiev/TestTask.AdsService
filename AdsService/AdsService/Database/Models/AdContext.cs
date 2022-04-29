using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataBaseServises.Models
{
  

    public class AdContext:DbContext
    {
        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }


        public AdContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Initial Catalog=AdsServiceDB; Integrated Security=true");
        }


    }
}
