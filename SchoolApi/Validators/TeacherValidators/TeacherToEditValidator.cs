using FluentValidation;
using SchoolApi.Dtos.TeacherDtos;

namespace SchoolApi.Validators.TeacherValidators;

public class TeacherToEditValidator: AbstractValidator<TeacherToEditDto>
{
    public TeacherToEditValidator()
    {
        RuleFor(id => id.Id).NotEmpty();
        RuleFor(level => level.TeachLevel).NotEmpty();
        RuleFor(course => course.CourseId).NotEmpty();
    }
}