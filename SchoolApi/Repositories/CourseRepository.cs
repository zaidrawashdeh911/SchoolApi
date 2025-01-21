using SchoolApi.Data;
using SchoolApi.Dtos.CourseDtos;
using SchoolApi.Models;

namespace SchoolApi.Repositories;

public class CourseRepository(IConfiguration config) : ICourseRepository
{
    private readonly DataContext _context = new(config);

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }

    public IEnumerable<Course> GetAllCourses()
    {
        IEnumerable<Course> courses = _context.Courses.ToList();
        return courses;
    }

    public Course GetSingleCourse(int courseId)
    {
        Course? course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
        if (course != null)
        {
            return course;
        }

        throw new Exception("Course not found");
    }

    public bool ValidTeacher(Course course)
    {
        if (!_context.Courses.Any(c => c.TeacherId == course.TeacherId))
        {
            if (_context.Teachers.Any(t => t.Id == course.TeacherId))
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public void AddCourse(Course course)
    {
        if (ValidTeacher(course))
        {
            _context.Courses.Add(course);
        }
        else
        {
            throw new Exception("Invalid teacher id");
        }
    }

    public void RemoveCourse(Course? course)
    {
        if (course != null)
        {
            _context.Courses.Remove(course);
        }
        else
        {
            throw new Exception("Cannot remove null course");
        }
    }
}