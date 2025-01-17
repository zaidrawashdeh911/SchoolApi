using System.ComponentModel.DataAnnotations;
using SchoolApi.Models.Users;

namespace SchoolApi.Models;
public class Course
{
    public int CourseId{get;init;}
    [MaxLength(50)]
    public string Name { get; init; } = "";
    public Teacher? Teachers{get; set;}
    public List<Student>? Students{get;set;}

    // public Course()
    // {
    //     CourseId++;
    //     this.Name = "testCourse";
    //     this.Teachers = new Teacher();
    //     this.Students = new Student[30];
    // }
    // public Course(Teacher teachers, Student[] students, string name, string id)
    // {
    //     CourseId++;
    //     this.Name = name;
    //     this.Teachers = teachers;
    //     this.Students = students;
    // }
    
}