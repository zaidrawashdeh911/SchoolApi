using SchoolApi.Data;
using SchoolApi.Models.Users;

namespace SchoolApi.Repositories;

public class TeacherRepository(IConfiguration configuration):ITeacherRepository
{
    private readonly DataContext _entityFramework = new (configuration);

    public bool SaveChanges()
    {
        return _entityFramework.SaveChanges() > 0;
    }

    public void AddEntity<T>(T entityToAdd)
    {
        if (entityToAdd != null)
        {
            _entityFramework.Add(entityToAdd);
        }
        throw new Exception("Can't add null entity");
    }

    public void RemoveEntity<T>(T entityToRemove)
    {
        if (entityToRemove != null)
        {
            _entityFramework.Remove(entityToRemove);
        }
        throw new Exception("Can't remove null entity");
    }

    public IEnumerable<Teacher> GetTeachers()
    {
        IEnumerable<Teacher> teachers = _entityFramework.Teachers.ToList();
        return teachers;
    }

    public Teacher GetSingleTeacher(int teacherId)
    {
        Teacher? teacherDb = _entityFramework.Teachers.FirstOrDefault(teacher => teacher.Id == teacherId);

        if (teacherDb != null)
        {
            return teacherDb;
        }
        throw new Exception("Can't find teacher");
    }
}