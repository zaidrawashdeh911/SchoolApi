using SchoolApi.Data;

namespace SchoolApi.Models.Users;

public class Teacher
{
    public int Id{init;get;}

    public Level TeachLevel { private set; get; }
    public Course? Course { private set; get; }
    // [MaxLength(50)]
    // public string CourseName { set; get; } = "";
    // public int CourseId { set; get; }
    
    public void Add(Level level, Course course)
    {
        TeachLevel = level;
        Course = course;
    }
}