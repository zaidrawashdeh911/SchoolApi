using SchoolApi.Data;

namespace SchoolApi.Models.Users;

public class Student
{
    public int StudentId{get;init;}
    public StudentType StudentType{get;set;}
    //public IList<CourseStudentRelation>? CourseStudentRelations{get; set;}
}