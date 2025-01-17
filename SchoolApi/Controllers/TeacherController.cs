using Microsoft.AspNetCore.Mvc;
using SchoolApi.Data;
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
            return teacher;
        }
        throw new Exception("No teacher found");
    }

    // [HttpPost("AddTeacher")]
    // public IActionResult AddTeacher(Teacher teacher)
    // {
    //     return Ok();
    // }
}