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
			modelBuilder.Entity<Bilet>()
				.HasKey(p => new {p.RezervareId, p.TrenId });

			modelBuilder.Entity<Bilet>()
				.HasOne<Rezervare>(s => s.Rezervare)
				.WithMany(p => p.Bilete)
				.HasForeignKey(s => s.RezervareId);

            modelBuilder.Entity<Bilet>()
                .HasOne<Tren>(o => o.Tren)
                .WithMany(p => p.Bilete)
                .HasForeignKey(o => o.TrenId);

			//One-to-One
			modelBuilder.Entity<User>()
				.HasOne(c => c.Cont)
				.WithOne()
				.HasForeignKey(c => c.UserId);

			//One-to-Many
			modelBuilder.Entity<>()
				.HasOne()
				.WithMany()
				.HasForeignKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}
