using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfiguration;
using SelfiesAWookie.Core.Selfies.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data
{
    public class Contexte : IdentityDbContext, IUnitOfWork
    {
        public Contexte(DbContextOptions options) : base(options)
        {
        }

        protected Contexte()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoEntityTypeConfiguration());
        }

        public DbSet<Selfie> Selfies { get; set; }
        public DbSet<Wookie> Wookies { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
