using SchoolApi.Data;
using SchoolApi.Models.Users;

namespace SchoolApi.Repositories.StudentRepository;

public class StudentRepository(IConfiguration config): IStudentRepository
{
    private readonly DataContext _context = new(config);
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;    
    }
    public IEnumerable<Student> GetStudents()
    {
        IEnumerable<Student> students = _context.Students.ToList();
        return students;
    }
    public Student GetSingleStudent(int studentId)
    {
        Student? studentDb = _context.Students.FirstOrDefault(student => student.Id == studentId);

        if (studentDb != null)
        {
            return studentDb;
        }
        throw new Exception("Can't find teacher");
    }
    public void AddStudent(Student? studentToAdd)
    {
        if (studentToAdd != null)
        {
            _context.Add(studentToAdd);
        }
        else
        {
            throw new Exception("Can't add null entity");
        }
    }
    public void RemoveStudent(Student? studentToRemove)
    {
        if (studentToRemove != null)
        {
            _context.Students.Remove(studentToRemove);
        }
        else
        {
            throw new Exception("Can't remove null student");
        }

    }
}