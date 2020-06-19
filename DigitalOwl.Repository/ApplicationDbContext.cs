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
            foreach (var relationship in modelBuilder
                                        .Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Group>()
                        .HasMany<GroupMember>(g => g.GroupMembers)
                        .WithOne(gm => gm.Group)
                        .HasForeignKey(gm => gm.GroupId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PollQuestion>()
                        .Ignore(b => b.Poll);
        }

        #endregion

        #region DbSet

        #region PollAndRelated

        /// <summary>
        /// Set Polls table in database.
        /// </summary>
        public DbSet<Poll> Polls { get; set; }

        /// <summary>
        /// Set PollQuestions table in database.
        /// </summary>
        public DbSet<PollQuestion> PollQuestions { get; set; }

        #endregion


        #region GroupAndRelated

        /// <summary>
        /// Set Groups table in database.
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Set GroupMembers table in database.
        /// </summary>
        public DbSet<GroupMember> GroupMembers { get; set; }

        #endregion

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