using SchoolApi.Data;

namespace SchoolApi.Models.Users;

public class Student
{
    public int Id{get;init;}
    public StudentType StudentType{get;private set;}
    public int Level{get;private set;}
    //public IList<CourseStudentRelation>? CourseStudentRelations{get; set;}

    public void Add(StudentType studentType, int level)
    {
        StudentType = studentType;
        Level = level;
    }
}