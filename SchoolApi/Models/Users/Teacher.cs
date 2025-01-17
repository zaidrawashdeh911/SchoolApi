using System.ComponentModel.DataAnnotations;
using SchoolApi.Data;

namespace SchoolApi.Models.Users;

public class Teacher
{
    public int TeacherId{init;get;}
    public Level TeachLevel { set; get; }
    public Course? Courses{set; get;}

    // public Teacher()
    // {
    //     this.Name = "testName";
    //     this.Subject = "testSubject";
    //     this.Age = 30;
    //     this.Gender = "testFemale";
    //     this.Phone ="test 12345678";
    //     this.Email = "test@simplify9.com";
    //     this.Address = "testAddress";
    //     this.TeachLevel = Level.EarlyChildhood;
    //     TeacherId++;
    // }
    // public Teacher(string name,string subject, int age, string gender, string phone, string email, string address="amman",Level teachLevel=Level.EarlyChildhood)
    // {
    //     this.Name = name;
    //     this.Subject = subject;
    //     this.Age = age;
    //     this.Gender = gender;
    //     this.Phone = phone;
    //     this.Email = email;
    //     this.Address = address;
    //     this.TeachLevel = teachLevel;
    //     TeacherId++;
    // }
    //
    // public override void Print()
    // {
    //     Console.WriteLine("Name:" + this.Name + " Age=" + this.Age+" id: " + TeacherId + " Subject: " + Subject);
    // }
    
}