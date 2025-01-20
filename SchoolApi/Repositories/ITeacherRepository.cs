using SchoolApi.Models.Users;

namespace SchoolApi.Repositories;

public interface ITeacherRepository
{
    public bool SaveChanges();
    public void AddEntity<T>(T entityToAdd);
    public void RemoveEntity<T>(T entityToRemove);
    public IEnumerable<Teacher> GetTeachers();
    public Teacher GetSingleTeacher(int userId);
}