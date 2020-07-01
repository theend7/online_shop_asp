using Microsoft.EntityFrameworkCore;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class ProdavnicaAspDarkoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-07DQN9D\SQLEXPRESS;Initial Catalog=ShopAsp;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KlijentConfiguration());
            modelBuilder.ApplyConfiguration(new UlogaConfiguration());
            modelBuilder.ApplyConfiguration(new ProizvodConfiguration());
            modelBuilder.ApplyConfiguration(new KategorijaConfiguration());
            modelBuilder.ApplyConfiguration(new CenaConfiguration());
            modelBuilder.ApplyConfiguration(new SlikaConfiguration());
            modelBuilder.ApplyConfiguration(new PorudzbinaConfiguration()); 
            modelBuilder.ApplyConfiguration(new KlijentUseCaseConfiguration());

            modelBuilder.Entity<Klijent>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Uloga>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Proizvod>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Kategorija>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Cena>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Slika>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Porudzbina>().HasQueryFilter(x => !x.isDeleted);
            


        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.Now;
                            e.DeletedAt = null;
                            e.isActive = true;
                            e.isDeleted = false;
                            e.ModifiedAt = null;
                            break;
                        case EntityState.Modified:
                            
                            if(e.isDeleted == true)
                            {
                                break;
                            }

                            e.ModifiedAt = DateTime.Now;
                            break;

                    }
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Uloga> Uloge { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Cena> Cene { get; set; }
        public DbSet<Slika> Slike { get; set; }
        public DbSet<Porudzbina> Porudzbine { get; set; }
        public DbSet<DetaljiPorudzbine> DetaljiPorudzbina { get; set; }
        public DbSet<KlijentUseCase> KlijentUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        

    }
}
