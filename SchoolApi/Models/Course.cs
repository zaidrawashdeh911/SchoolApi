using System.ComponentModel.DataAnnotations;
using SchoolApi.Models.Users;

namespace SchoolApi.Models;
public class Course
{
    public int Id{get;init;}
    [MaxLength(50)]
    public string Name { get; init; } = "";
    
    public int TeacherId{get;set;}
    public Teacher? Teacher{get; set;}
    public List<CourseStudentRelation>? CourseStudentRelations{get; set;}
}