using SchoolApi.Models;

namespace SchoolApi.Dtos.CourseDtos;

public class CourseToEditDto
{
    public int Id { get; init; }
    public string Name { get; set; } = "";
    public int TeacherId { get; set; }
    //public List<CourseStudentRelation>? CourseStudentRelations { get; set; }
}