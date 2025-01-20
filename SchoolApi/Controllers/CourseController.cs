using Microsoft.AspNetCore.Mvc;
using SchoolApi.Data;

namespace SchoolApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController:ControllerBase
{
    private readonly DataContext _context;

    public CourseController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("GetAllCourses")]
    public void GetAllCourses()
    {
        
    }
}
