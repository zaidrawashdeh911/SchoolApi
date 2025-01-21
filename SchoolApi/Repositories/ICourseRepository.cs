using SchoolApi.Models;

namespace SchoolApi.Repositories;

public interface ICourseRepository
{
    public bool SaveChanges();
    public IEnumerable<Course> GetAllCourses();
    public Course GetSingleCourse(int courseId);
    public bool ValidTeacher(Course course);
    public void AddCourse(Course courseToAdd);
    public void RemoveCourse( Course courseToRemove);
}