namespace SchoolApi.Models.Users;

public class NationalStudent(string nationalId): Student
{
    private string NationalId{ get; init; } = nationalId;// using primary constructor
    
    
    public override void ExamType()
    {
        Console.WriteLine("The Student with national number: " + NationalId + "takes National exam");
    }
}