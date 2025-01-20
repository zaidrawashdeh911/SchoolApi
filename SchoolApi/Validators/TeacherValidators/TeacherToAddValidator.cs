using FluentValidation;
using SchoolApi.Dtos.TeacherDtos;

namespace SchoolApi.Validators.TeacherValidators;

public class TeacherToAddValidator: AbstractValidator<TeacherToAddDto>
{
    public TeacherToAddValidator()
    {
        RuleFor(level => level.TeachLevel).NotEmpty();
        RuleFor(courseId => courseId.CourseId).NotEmpty();
    }
}