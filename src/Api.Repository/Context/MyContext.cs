using Api.Domain.Entities.UserEntity;
using Api.Domain.Entities.UserEntity.ValueObject;
using Api.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

    }

}
