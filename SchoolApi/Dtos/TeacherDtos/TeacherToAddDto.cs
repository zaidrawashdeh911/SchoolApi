using SchoolApi.Data;

namespace SchoolApi.Dtos.TeacherDtos;

public class TeacherToAddDto
{
    public Level TeachLevel { set; get; }
    public int CourseId { set; get; }
    // public string CourseName { set; get; } = "";
    // public int CourseId { set; get; }
}