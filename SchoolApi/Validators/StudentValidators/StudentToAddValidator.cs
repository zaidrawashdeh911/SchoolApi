using FluentValidation;
using SchoolApi.Dtos.StudentDtos;

namespace SchoolApi.Validators.StudentValidators;

public class StudentToAddValidator: AbstractValidator<StudentToAddDto>
{
    public StudentToAddValidator()
    {
        RuleFor(type => type.StudentType).NotEmpty();
        RuleFor(grade => grade.Level).NotEmpty()
            .InclusiveBetween(1, 12);
    }
}