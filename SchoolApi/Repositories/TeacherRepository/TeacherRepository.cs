using SchoolApi.Data;
using SchoolApi.Models.Users;

namespace SchoolApi.Repositories.TeacherRepository;

public class TeacherRepository(IConfiguration configuration):ITeacherRepository
{
    private readonly DataContext _context = new (configuration);

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }

    public void AddTeacher(Teacher? teacher)
    {
        if (teacher != null)
        {
            _context.Teachers.Add(teacher);
        }
        else
        {
            throw new Exception("Can't add null entity");
        }

    }

    public void RemoveTeacher(Teacher? teacher)
    {
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
        }
        else
        {
            throw new Exception("Can't remove null entity");
        }
    }

    public IEnumerable<Teacher> GetTeachers()
    {
        IEnumerable<Teacher> teachers = _context.Teachers.ToList();
        return teachers;
    }

    public Teacher GetSingleTeacher(int teacherId)
    {
        Teacher? teacherDb = _context.Teachers.FirstOrDefault(teacher => teacher.Id == teacherId);

        if (teacherDb != null)
        {
            return teacherDb;
        }
        throw new Exception("Can't find teacher");
    }
}