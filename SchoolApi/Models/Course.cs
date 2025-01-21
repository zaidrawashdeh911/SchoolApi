using System.ComponentModel.DataAnnotations;
using SchoolApi.Dtos.CourseDtos;
using SchoolApi.Models.Users;

namespace SchoolApi.Models;
public class Course
{
    public int Id{get; private init;}
    [MaxLength(50)]
    public string Name { get; private set; } = "";
    
    public int TeacherId{get;private set;}
    public Teacher? Teacher{get; private set;}
    //public List<CourseStudentRelation>? CourseStudentRelations{get; private set;}

    public void TaughtBy(int teacherId)
    {
        TeacherId = teacherId;
    }

    public void Add(CourseToAddDto course)
    {
        Name = course.Name;
        TeacherId = course.TeacherId;
        //CourseStudentRelations = course.CourseStudentRelations;
    }
}