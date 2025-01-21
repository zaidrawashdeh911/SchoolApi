using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Data;
using SchoolApi.Dtos.CourseDtos;
using SchoolApi.Models;
using SchoolApi.Models.Users;
using SchoolApi.Repositories;
using SchoolApi.Validators.CourseValidators;

namespace SchoolApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController:ControllerBase
{
    private readonly DataContext _context;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseController(IConfiguration config, ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
        _context = new DataContext(config);
        _mapper = new Mapper(new MapperConfiguration(configure =>
        {
            configure.CreateMap<CourseToAddDto, Course>();
            configure.CreateMap<Course, CourseToReturnDto>();
            configure.CreateMap<CourseToEditDto, CourseToAddDto>().ReverseMap();
        }));
    }

    [HttpGet("GetCourses")]
    public IEnumerable<CourseToReturnDto> GetCourses()
    {
        IEnumerable<CourseToReturnDto> returnCourses = _mapper
            .Map<IEnumerable<CourseToReturnDto>>(_courseRepository.GetAllCourses());
        return returnCourses;
    }

    [HttpGet("GetCoursesById/{courseId}")]
    public CourseToReturnDto GetSingleCourse(int courseId)
    {
        CourseToReturnDto returnCourse = _mapper
            .Map<CourseToReturnDto>(_courseRepository.GetSingleCourse(courseId));
        return returnCourse;
    }
    
    [HttpPost("AddCourse")]
    public IActionResult AddCourse(CourseToAddDto course)
    {
        CourseToAddValidator toAddValidator = new CourseToAddValidator();
        ValidationResult result = toAddValidator.Validate(course);
        if (!result.IsValid)
        {
            foreach (var failure in result.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
            return BadRequest();
        }
        
        Course courseDb = new Course();
        courseDb.TaughtBy(course.TeacherId);
        courseDb.Add(course);
        
        _courseRepository.AddCourse(courseDb);
        if (_courseRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Failed to add course");
    }

    [HttpPut("UpdateCourse")]
    public IActionResult UpdateCourse(CourseToEditDto course)
    {
        CourseToEditValidator toEditValidator = new CourseToEditValidator();
        ValidationResult result = toEditValidator.Validate(course);
        if (!result.IsValid)
        {
            foreach(var failure in result.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
            return BadRequest();
        }
        Course courseDb = _courseRepository.GetSingleCourse(course.Id);
        courseDb.Add(_mapper.Map<CourseToAddDto>(course));

        if (_courseRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Failed to update course");
    }

    [HttpDelete("DeleteCourse/{courseId}")]
    public IActionResult DeleteCourse(int courseId)
    {
        Course courseDb = _courseRepository.GetSingleCourse(courseId);

            _courseRepository.RemoveCourse(courseDb);
            if (_courseRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to delete course");
    }
}
