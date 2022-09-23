using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment3.Entities{
    public partial class KanbanContext : DbContext {
        public KanbanContext(DbContextOptions<KanbanContext> options) 
            : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>(entity => {
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.email).IsRequired();
            });
            modelBuilder.Entity<Task>(entity => {
                entity.Property(e => e.title).IsRequired();
                entity.Property(e => e.description).IsRequired(false);
            });
            modelBuilder.Entity<Tag>(entity => {
                entity.Property(e => e.name).IsRequired().HasMaxLength(50);
            });
        }

        partial void onModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
