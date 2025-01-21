using FluentValidation;
using SchoolApi.Dtos.StudentDtos;

namespace SchoolApi.Validators.StudentValidators;

public class StudentToEditValidator: AbstractValidator<StudentToEditDto>
{
    public StudentToEditValidator()
    {
        RuleFor(id => id.StudentId).NotEmpty();
        RuleFor(type => type.StudentType).NotEmpty();
        RuleFor(grade => grade.Level).NotEmpty()
            .InclusiveBetween(1, 12);
    }
}