using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos.StudentDtos;
using SchoolApi.Models.Users;
using SchoolApi.Repositories.StudentRepository;
using SchoolApi.Validators.StudentValidators;

namespace SchoolApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
        _mapper = new Mapper(new MapperConfiguration(configure =>
        {
            configure.CreateMap<Student, StudentToReturnDto>();
        }));
    }

    [HttpGet("GetStudents")]
    public IEnumerable<StudentToReturnDto> GetStudents()
    {
        IEnumerable<StudentToReturnDto> returnStudents = _mapper
            .Map<IEnumerable<StudentToReturnDto>>(_studentRepository.GetStudents());
        
        return returnStudents;
    }

    [HttpGet("GetStudent/{studentId}")]
    public StudentToReturnDto GetSingleStudent(int studentId)
    {
        StudentToReturnDto returnStudent = _mapper
            .Map<StudentToReturnDto>(_studentRepository.GetSingleStudent(studentId));
        
        return returnStudent;
    }

    [HttpPost("AddStudent")]
    public IActionResult AddStudent(StudentToAddDto studentToAdd)
    {
        StudentToAddValidator toAddValidator = new StudentToAddValidator();
        ValidationResult result = toAddValidator.Validate(studentToAdd);
        if (!result.IsValid)
        {
            foreach(var failure in result.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
            return BadRequest();
        }
        
        Student studentDb = new Student();
        studentDb.Add(studentToAdd.StudentType,studentToAdd.Level);
        _studentRepository.AddStudent(studentDb);
        
        if (_studentRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Failed to add student");
    }

    [HttpPut("UpdateStudent")]
    public IActionResult UpdateStudent(StudentToEditDto student)
    {
        StudentToEditValidator toUpdateValidator = new StudentToEditValidator();
        ValidationResult result = toUpdateValidator.Validate(student);
        if (!result.IsValid)
        {
            foreach(var failure in result.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
            return BadRequest();
        }
        Student studentDb = _studentRepository.GetSingleStudent(student.StudentId);
        studentDb.Add(student.StudentType,student.Level);
        if (_studentRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Failed to update student");
    }

    [HttpDelete("DeleteStudent/{studentId}")]
    public IActionResult DeleteStudent(int studentId)
    {
        Student studentDb = _studentRepository.GetSingleStudent(studentId);
        
        _studentRepository.RemoveStudent(studentDb);
        if (_studentRepository.SaveChanges())
        {
            return Ok();
        }
        throw new Exception("Failed to delete student");
    }
}

