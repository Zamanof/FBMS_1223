using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabBase_First;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lib> Libs { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Press> Presses { get; set; }

    public virtual DbSet<SCard> SCards { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TCard> TCards { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(25);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasMaxLength(50);
            entity.Property(e => e.IdAuthor).HasColumnName("Id_Author");
            entity.Property(e => e.IdCategory).HasColumnName("Id_Category");
            entity.Property(e => e.IdPress).HasColumnName("Id_Press");
            entity.Property(e => e.IdThemes).HasColumnName("Id_Themes");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Author");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Category");

            entity.HasOne(d => d.IdPressNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Press");

            entity.HasOne(d => d.IdThemesNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdThemes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Theme");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdFaculty).HasColumnName("Id_Faculty");
            entity.Property(e => e.Name).HasMaxLength(10);

            entity.HasOne(d => d.IdFacultyNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_Faculty");
        });

        modelBuilder.Entity<Lib>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(25);
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pictures__3214EC0783B66193");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Picture1).HasColumnName("Picture");

            entity.HasOne(d => d.Book).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pictures__BookId__5CD6CB2B");
        });

        modelBuilder.Entity<Press>(entity =>
        {
            entity.ToTable("Press");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<SCard>(entity =>
        {
            entity.ToTable("S_Cards");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.DateOut).HasColumnType("datetime");
            entity.Property(e => e.IdBook).HasColumnName("Id_Book");
            entity.Property(e => e.IdLib).HasColumnName("Id_Lib");
            entity.Property(e => e.IdStudent).HasColumnName("Id_Student");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Book");

            entity.HasOne(d => d.IdLibNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdLib)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Lib");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Stud");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.IdGroup).HasColumnName("Id_Group");
            entity.Property(e => e.LastName).HasMaxLength(25);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Group");
        });

        modelBuilder.Entity<TCard>(entity =>
        {
            entity.ToTable("T_Cards");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.DateOut).HasColumnType("datetime");
            entity.Property(e => e.IdBook).HasColumnName("Id_Book");
            entity.Property(e => e.IdLib).HasColumnName("Id_Lib");
            entity.Property(e => e.IdTeacher).HasColumnName("Id_Teacher");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Book");

            entity.HasOne(d => d.IdLibNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdLib)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Lib");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Teacher");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.IdDep).HasColumnName("Id_Dep");
            entity.Property(e => e.LastName).HasMaxLength(25);

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdDep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_Dep");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
