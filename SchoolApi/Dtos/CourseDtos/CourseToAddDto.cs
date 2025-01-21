// using SchoolApi.Models;
// using SchoolApi.Models.Users;

namespace SchoolApi.Dtos.CourseDtos;

public class CourseToAddDto
{
    public string Name { get; set; } = "";
    public int TeacherId { get; set; }
    //public Teacher? Teacher { get; set; }
    //public List<CourseStudentRelation>? CourseStudentRelations{get; private set;}

}