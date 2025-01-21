using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Data;
using SchoolApi.Dtos.TeacherDtos;
using SchoolApi.Models;
using SchoolApi.Models.Users;
using SchoolApi.Repositories.TeacherRepository;
using SchoolApi.Validators.TeacherValidators;

namespace SchoolApi.Controllers;



[ApiController]
[Route("[controller]")]
public class TeacherController: ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly ITeacherRepository _teacherRepository;

    public TeacherController(IConfiguration config, ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
        _context = new DataContext(config);
        _mapper = new Mapper(new MapperConfiguration(configure =>
        {
            configure.CreateMap<Teacher,TeacherToReturnDto>();
        }));
    }
    
    [HttpGet("GetTeachers")]
    public IEnumerable<TeacherToReturnDto> GetTeachers()
    {
        IEnumerable<TeacherToReturnDto> returnTeachers = _mapper.Map<IEnumerable<TeacherToReturnDto>>(_teacherRepository.GetTeachers());
        
        return returnTeachers;
    }

    [HttpGet("GetSingleTeacher/{teacherId}")]
    public TeacherToReturnDto GetSingleTeacher(int teacherId)
    {
        TeacherToReturnDto returnTeacher= _mapper.Map<TeacherToReturnDto>(_teacherRepository.GetSingleTeacher(teacherId));
        
        return returnTeacher;
    }

    [HttpPost("AddTeacher")]
    public IActionResult AddTeacher(TeacherToAddDto teacherToAdd)
    {
        TeacherToAddValidator toAddValidator = new TeacherToAddValidator();
        ValidationResult result = toAddValidator.Validate(teacherToAdd);
        if (!result.IsValid)
        {
            foreach(var failure in result.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
            return BadRequest();
        }
        
        Teacher teacherDb = new Teacher();
        
        Course? course = _context.Courses.FirstOrDefault(c => c.Id == teacherToAdd.CourseId);

        if (course != null)
        {
            teacherDb.Add(teacherToAdd.TeachLevel, course);
        }
        
        
        _teacherRepository.AddTeacher(teacherDb);

        if (_teacherRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Failed to add teacher");
    }

    [HttpPut("UpdateTeacher")]
    public IActionResult UpdateTeacher(TeacherToEditDto teacher)
    {
        TeacherToEditValidator toEditValidator = new TeacherToEditValidator();
        ValidationResult result = toEditValidator.Validate(teacher);
        if (!result.IsValid)
        {
            foreach(var failure in result.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
            return BadRequest();
        }

        Teacher? teacherDb = _teacherRepository.GetSingleTeacher(teacher.Id);
        if (teacherDb != null)
        {
            Course? course = _context.Courses.FirstOrDefault(course => course.Id == teacher.CourseId);

            if (course != null)
            {
                teacherDb.Add(teacher.TeachLevel, course);
            }
            if (_teacherRepository.SaveChanges())
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
        Teacher teacherDb = _teacherRepository.GetSingleTeacher(teacherId);

        _teacherRepository.RemoveTeacher(teacherDb);
        if (_teacherRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Failed to delete teacher");
    }
}