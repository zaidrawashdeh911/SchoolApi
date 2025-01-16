namespace SchoolApi.Models.Users;

public class InternationalStudent(string passport): Student
{
    private string PassportNumber{get; init; } = passport;// primary constructor
    
    public override void ExamType()
    {
        Console.WriteLine("The Student with passport number: " + PassportNumber + " takes International exam");
    }
}