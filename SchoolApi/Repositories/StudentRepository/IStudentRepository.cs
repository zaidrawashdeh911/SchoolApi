using SchoolApi.Models.Users;

namespace SchoolApi.Repositories.StudentRepository;

public interface IStudentRepository
{
    public bool SaveChanges();
    public IEnumerable<Student> GetStudents();
    public Student GetSingleStudent(int studentId);
    public void AddStudent(Student studentToAdd);
    public void RemoveStudent( Student studentToRemove);
}