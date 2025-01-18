using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Dtos;

public class TeacherToAddDto
{
    public Level TeacherLevel { set; get; }
    public int CourseId { set; get; }
    // public string CourseName { set; get; } = "";
    // public int CourseId { set; get; }
}