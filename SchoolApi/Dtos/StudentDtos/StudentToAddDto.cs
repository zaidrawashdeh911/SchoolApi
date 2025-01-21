using SchoolApi.Data;

namespace SchoolApi.Dtos.StudentDtos;

public class StudentToAddDto
{
    public StudentType StudentType { set; get; }
    public int Level { set; get; }
    //public ICollection<CourseStudentRelation>? CourseStudentRelations{get; set;}
}