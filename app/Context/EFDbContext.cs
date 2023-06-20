using app.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace app.Context
{
    public class EFDbContext : DbContext
    {
        #region Ctor
             
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
            base.Database.Migrate();
        }

        #endregion Ctor

        #region DbContext

        public new DbSet<TEntity> Set<TEntity>() 
            where TEntity : class => base.Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(contact => contact.Owner)
                .WithMany(user => user.Contacts)
                .HasForeignKey(contact => contact.UserId);

            modelBuilder.Entity<Contact>()
                .HasOne(contact => contact.User)
                .WithMany()
                .HasForeignKey(contact => contact.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .ToTable("Messages")
                .HasOne(message => message.User)
                .WithMany(user => user.Messages);

            var publisher = new User
            {
                Id = Guid.NewGuid(),
            };
            var subscriber = new User
            {
                Id = Guid.NewGuid(),
            };

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasData(new[] { publisher, subscriber });

            modelBuilder.Entity<Contact>()
                .ToTable("Contacts")
                .HasData(new Contact { 
                    Id = subscriber.Id, 
                    UserId = publisher.Id,
                });

            base.OnModelCreating(modelBuilder);
        }

        #endregion DbContext
    }
}
