using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;
using SchoolApi.Models.Meals;
using SchoolApi.Models.Users;

namespace SchoolApi.Data;

public class DataContext(IConfiguration config) : DbContext
{
    public DbSet<Human> Humans { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseStudentRelation> CourseStudentRelations { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"),
                optsBuilder => optsBuilder.EnableRetryOnFailure());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // how to create a migration using .net core and ef core  and pstgrs
        modelBuilder.Entity<Human>()
            .ToTable("Humans")
            .HasKey(human => human.HumanId);
        modelBuilder.Entity<Human>()
            .Property(human => human.HumanId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Teacher>()
            .ToTable("Teachers")
            .HasKey(teacher => teacher.TeacherId);
        modelBuilder.Entity<Teacher>()
            .Property(teacher => teacher.TeacherId)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Student>()
            .ToTable("Students")
            .HasKey(student => student.StudentId);
        modelBuilder.Entity<Student>()
            .Property(student => student.StudentId)
            .ValueGeneratedOnAdd();
        
        // modelBuilder.Entity<InternationalStudent>()
        //     .ToTable("InternationalStudents")
        //     .HasKey(iStudent => iStudent.InternationalStudentId);
        //
        // modelBuilder.Entity<NationalStudent>()
        //     .ToTable("NationalStudents")
        //     .HasKey(nStudent => nStudent.NationalStudentId);
        
        modelBuilder.Entity<Course>()
            .ToTable("Courses")
            .HasKey(course => course.CourseId);
        modelBuilder.Entity<Course>()
            .Property(course => course.CourseId)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Course>()
            .HasOne(course => course.Teacher)
            .WithOne(teacher => teacher.Course)
            .HasForeignKey<Course>(course => course.TeacherId);
        
        modelBuilder.Entity<CourseStudentRelation>()
            .HasKey(studentCourse => new { studentCourse.StudentId, studentCourse.CourseId });

        modelBuilder.Entity<CourseStudentRelation>()
            .HasOne(studentCourse => studentCourse.Student)
            .WithMany(student => student.CourseStudentRelations)
            .HasForeignKey(studentCourse => studentCourse.StudentId);

        modelBuilder.Entity<CourseStudentRelation>()
            .HasOne(studentCourse => studentCourse.Course)
            .WithMany(course => course.CourseStudentRelations)
            .HasForeignKey(studentCourse => studentCourse.CourseId);

        // modelBuilder.Entity<Order>()
        //     .ToTable("Orders")
        //     .HasKey(order => order.OrderId);
        // modelBuilder.Entity<Student>()
        //     .Property(order => order.OrderId)
        //     .ValueGeneratedOnAdd();
    }
}