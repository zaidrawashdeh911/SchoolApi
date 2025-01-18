using System.ComponentModel.DataAnnotations;
using SchoolApi.Models.Users;

namespace SchoolApi.Models;
public class Course
{
    public int CourseId{get;init;}
    [MaxLength(50)]
    public string Name { get; init; } = "";
    
    public int TeacherId{get;set;}
    public Teacher? Teacher{get; set;}
    // public ICollection<CourseStudentRelation>? CourseStudentRelations{get; set;}
}