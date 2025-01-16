using SchoolApi.Models.Users;

namespace SchoolApi.Models;
public class Course
{
    private static int CourseId{get;set;}
    public string Name{get;set;}
    private Teacher Teachers{get;set;}
    private Student[] Students{get;set;}

    public Course()
    {
        CourseId++;
        this.Name = "testCourse";
        this.Teachers = new Teacher();
        this.Students = new Student[30];
    }
    public Course(Teacher teachers, Student[] students, string name, string id)
    {
        CourseId++;
        this.Name = name;
        this.Teachers = teachers;
        this.Students = students;
    }
    
}