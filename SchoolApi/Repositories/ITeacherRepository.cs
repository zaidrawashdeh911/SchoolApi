using SchoolApi.Models.Users;

namespace SchoolApi.Repositories;

public interface ITeacherRepository
{
    public bool SaveChanges();
    public void AddTeacher(Teacher teacher);
    public void RemoveTeacher(Teacher teacher);
    public IEnumerable<Teacher> GetTeachers();
    public Teacher GetSingleTeacher(int userId);
}