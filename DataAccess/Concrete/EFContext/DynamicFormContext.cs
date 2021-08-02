using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess
{
    public partial class DynamicFormContext : DbContext
    {
        public DynamicFormContext()
        {
        }

        public DynamicFormContext(DbContextOptions<DynamicFormContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnsweredForm> AnsweredForms { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=DynamicForm;Username=admin;Password=taha1919gokce");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<AnsweredForm>(entity =>
            {
                entity.ToTable("AnsweredForm");

                entity.Property(e => e.Id).HasMaxLength(200);
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.HasIndex(e => e.UserId, "fki_FK_UserId");

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Forms)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasIndex(e => e.FormId, "fki_FK_FormId_Question");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormId_Question");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasIndex(e => e.AnsweredFormId, "fki_FK_AnsweredFormId");

                entity.HasIndex(e => e.FormId, "fki_FK_FormId_Reply");

                entity.HasIndex(e => e.QuestionId, "fki_FK_QuestionId");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.AnsweredFormId).HasMaxLength(200);

                entity.HasOne(d => d.AnsweredForm)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.AnsweredFormId)
                    .HasConstraintName("FK_AnsweredFormId");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormId_Reply");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}