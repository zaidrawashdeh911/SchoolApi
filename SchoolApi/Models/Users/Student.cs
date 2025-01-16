namespace SchoolApi.Models.Users;

public class Student: Human
{
    private Course [] Courses{set;get;}
    private static int StudentId{get;set;}
    public Student()
    {
        this.Name = "testName";
        this.Age = 30;
        this.Gender = "testFemale";
        this.Phone ="test 12345678";
        this.Email = "test@simplify9.com";
        this.Address = "testAddress";
        Courses = new Course[8];
        StudentId++;
    }

    public Student(string name, Course[] courses, int age, string gender, string phone, string email, string address="Jordan")
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
        this.Phone = phone;
        this.Email = email;
        this.Address = address;
        this.Courses = courses;
        StudentId++;
        
    }
    
    public override void Print()
    {
        Console.WriteLine("Name:" + this.Name + " Courses= " + this.Courses+" id: " + StudentId);
    }

    public void PrintName()
    {
        Console.WriteLine(" The Student: " + this.Name);
    }

    public virtual void ExamType()
    {
        Console.WriteLine("The Student takes a random exam type");
    }
    
}