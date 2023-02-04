using System;
using NewRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace NewRepo.Data
{
	public class TrenuriContext : DbContext
	{
		public DbSet <User> Users { get; set; }
		public DbSet <Rezervare> Reserv { get; set; }
		public DbSet <Bilet> Bilete { get; set; }
		public DbSet <Tren> Trenuri { get; set; }

		public DataBaseContext(DbContextOptions<CatForumContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			///Many-to-Many relation
			modelBuilder.Entity<>()
				.HasKey(p => new { });

			modelBuilder.Entity<>()
				.HasOne<>(s => s.)
				.WithMany(p => p.)
				.HasForeignKey(s => s.);

            modelBuilder.Entity<>()
                .HasOne<>(o => o.)
                .WithMany(p => p.)
                .HasForeignKey(o => o.);

            base.OnModelCreating(modelBuilder);
        }

    }
}
