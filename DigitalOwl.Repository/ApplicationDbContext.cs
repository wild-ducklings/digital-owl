using System.Linq;
using System.Threading.Tasks;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Repository.Interface.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalOwl.Repository
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>, IDbContext
    {
        #region .Ctor

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        #endregion

        #region DbSet
        

        #endregion

        #region SaveMethods

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        #endregion
    }
}