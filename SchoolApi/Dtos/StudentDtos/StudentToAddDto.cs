using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Dtos;

public class StudentToAddDto
{
    public StudentType StudentType { set; get; }
    //public ICollection<CourseStudentRelation>? CourseStudentRelations{get; set;}
}