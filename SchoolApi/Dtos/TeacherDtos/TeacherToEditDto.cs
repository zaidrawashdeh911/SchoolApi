using SchoolApi.Data;

namespace SchoolApi.Dtos.TeacherDtos;

public class TeacherToEditDto
{
    public int Id { get; init; }
    public Level TeachLevel { get; set; }
    public int CourseId { get; set; }
}