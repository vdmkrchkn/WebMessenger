using app.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.Context
{
    public class EFDbContext : DbContext
    {
        #region Ctor
             
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options){ }

        #endregion Ctor

        #region DbContext

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<MessageEntity>();            

            base.OnModelCreating(modelBuilder);
        }

        #endregion DbContext
    }
}
