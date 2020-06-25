using System;
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

            modelBuilder.Entity<Group>()
                        .HasMany<GroupMessage>(g => g.GroupMessages)
                        .WithOne(gm => gm.Group)
                        .HasForeignKey(gm => gm.GroupId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Poll>()
                        .HasMany<PollQuestion>(g => g.PollQuestions)
                        .WithOne(gm => gm.Poll)
                        .HasForeignKey(gm => gm.PollId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PollQuestion>()
                        .Ignore(b => b.Poll);

            modelBuilder.Entity<PollQuestion>()
                        .HasMany<PollAnswer>(g => g.QuestionAnswers)
                        .WithOne(gm => gm.PollQuestion)
                        .HasForeignKey(gm => gm.PollQuestionId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PollAnswer>()
                        .Ignore(b => b.PollQuestion);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Kuba",
                NormalizedUserName = "KUBA",
                PasswordHash = "AQAAAAEAACcQAAAAEAKT5wd/GwEO+6jG/pg1z2bW+g/u/nzqVTlEEqS94ok6uz5KjjUtGpqHbZoBulAyBw==",
                SecurityStamp = "",
                ConcurrencyStamp = "",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Role = "Administrator"
            });

            modelBuilder.Entity<GroupPolice>().HasData(new GroupPolice
            {
                Id = 1,
                Name = "CanAddUser",
                CreatedById = 1,
                CreatedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<GroupPolice>().HasData(new GroupPolice
            {
                Id = 2,
                Name = "CanAddAndDeleteUser",
                CreatedById = 1,
                CreatedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<GroupPolice>().HasData(new GroupPolice
            {
                Id = 3,
                Name = "CanModifyAdnDeleteGroup",
                CreatedById = 1,
                CreatedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<GroupPolice>().HasData(new GroupPolice
            {
                Id = 4,
                Name = "CanEverything",
                CreatedById = 1,
                CreatedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<GroupRole>().HasData(new GroupRole
            {
                Id = 1,
                Name = "Participant",
                GroupPoliceId = 1,
                CreatedById = 1,
                CreatedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<GroupRole>().HasData(new GroupRole
            {
                Id = 2,
                Name = "Administrator",
                GroupPoliceId = 2,
                CreatedById = 1,
                CreatedDate = DateTime.UtcNow,
            });
            modelBuilder.Entity<GroupRole>().HasData(new GroupRole
            {
                Id = 3,
                Name = "Owner",
                GroupPoliceId = 4,
                CreatedById = 1,
                CreatedDate = DateTime.UtcNow,
            });
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

        /// <summary>
        /// Set PollAnswers table in database.
        /// </summary>
        public DbSet<PollAnswer> PollAnswer { get; set; }

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

        /// <summary>
        /// Set GroupMessages table in database.
        /// </summary>
        public DbSet<GroupMessage> GroupMessages { get; set; }

        /// <summary>
        /// Set GroupRoles table in database.
        /// </summary>
        public DbSet<GroupRole> GroupRoles { get; set; }

        /// <summary>
        /// Set GroupPolices table in database.
        /// </summary>
        public DbSet<GroupPolice> GroupPolices { get; set; }

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