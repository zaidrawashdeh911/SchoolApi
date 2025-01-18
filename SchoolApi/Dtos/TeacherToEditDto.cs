using SchoolApi.Data;

namespace SchoolApi.Dtos;

public class TeacherToEditDto
{
    public int TeacherId { get; set; }
    public Level TeachLevel { get; set; }
}