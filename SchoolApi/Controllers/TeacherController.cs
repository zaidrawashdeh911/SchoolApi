using Microsoft.AspNetCore.Mvc;
using SchoolApi.Data;
using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Models.Users;

namespace SchoolApi.Controllers;



[ApiController]
[Route("[controller]")]
public class TeacherController(IConfiguration config): ControllerBase
{
    private readonly DataContext _entityFramework= new(config);
    
    [HttpGet("GetTeachers")]
    public IEnumerable<Teacher> GetTeachers()
    {
        IEnumerable<Teacher> teachers = _entityFramework.Teachers.ToList<Teacher>();
        return teachers;
    }

    [HttpGet("GetSingleTeacher/{teacherId}")]
    public Teacher GetSingleTeacher(int teacherId)
    {
        Teacher? teacher = _entityFramework.Teachers
            .Where(t => t.TeacherId == teacherId)
            .FirstOrDefault<Teacher>();

        if (teacher != null)
        {
            var returnTeacher = new Teacher()
            {
                TeacherId = teacher.TeacherId,
                TeachLevel = teacher.TeachLevel
            };
            return returnTeacher;
        }
        throw new Exception("No teacher found");
    }

    [HttpPost("AddTeacher")]
    public IActionResult AddTeacher(TeacherToAddDto teacher)
    {
        if (teacher != null)
        {
            Teacher teacherDb = new Teacher();

            teacherDb.TeachLevel = teacher.TeacherLevel;
            var course = _entityFramework.Courses.FirstOrDefault(c => c.CourseId == teacher.CourseId);
            teacherDb.Course= course;
            _entityFramework.Teachers.Add(teacherDb);

            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            throw new Exception("Failed to add teacher");
        }
        throw new Exception("Cannot add null teacher");
    }

    [HttpPut("UpdateTeacher")]
    public IActionResult UpdateTeacher(TeacherToEditDto teacher)
    {
        Teacher? teacherDb = _entityFramework.Teachers
            .Where(t => t.TeacherId == teacher.TeacherId)
            .FirstOrDefault<Teacher>();
        if (teacherDb != null)
        {
            teacherDb.TeachLevel = teacher.TeachLevel;
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            throw new Exception("Failed to update teacher");
        }
        throw new Exception("Failed to get teacher");
    }
    
    [HttpDelete("DeleteTeacher/{teacherId}")]
    public IActionResult DeleteTeacher(int teacherId)
    {
        Teacher? teacherDb = _entityFramework.Teachers
            .Where(teacher => teacher.TeacherId == teacherId)
            .FirstOrDefault<Teacher>();

        if (teacherDb != null)
        {
            _entityFramework.Teachers.Remove(teacherDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
            throw new Exception("Failed to delete teacher");
        }
        throw new Exception("Cannot delete null teacher");
    }
}