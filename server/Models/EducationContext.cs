using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class EducationContext: DbContext
    {
        public EducationContext (DbContextOptions<EducationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                eb =>
                {
                    eb.HasKey(b => b.Id);
                    eb.Property(b => b.Id).HasColumnType("UNIQUEIDENTIFIER");
                    eb.Property(b => b.FirstName).HasColumnType("NVARCHAR(100)").IsRequired();
                    eb.Property(b => b.MiddleName).HasColumnType("NVARCHAR(100)");
                    eb.Property(b => b.LastName).HasColumnType("NVARCHAR(100)").IsRequired();
                });
        }
        public DbSet<User> Users { get; set; }
    }
}