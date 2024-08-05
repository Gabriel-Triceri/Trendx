using Microsoft.EntityFrameworkCore;
using Lista_de_Tarefas.Models;

namespace Lista_de_Tarefas.Persistence
{
    public class DbContextSqlServer : DbContext
    {
        public DbContextSqlServer(DbContextOptions<DbContextSqlServer> options) : base(options)
        {
        }

        public DbSet<Tasks> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

   
            modelBuilder.Entity<Tasks>()
                .HasKey(t => t.id);

            modelBuilder.Entity<Tasks>()
                .Property(t => t.title)
                .IsRequired();

            modelBuilder.Entity<Tasks>()
                .Property(t => t.description)
                .IsRequired();

            modelBuilder.Entity<Tasks>()
                .Property(t => t.completed)
                .IsRequired();
        }
    }
}
