using DocumentinAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentinAPI.Data
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> opt) : base(opt)
        {

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentVersion> DocumentVersions { get; set; }
        public DbSet<DocumentXTag> DocumentXTags { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<FolderPermission> FolderPermissions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserXGroup> UserXGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<DocumentXTag>()
                .HasKey(dt => new { dt.DocumentId, dt.TagId });            
            
            modelBuilder.Entity<UserXGroup>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
