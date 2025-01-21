using FluentValidation;
using SchoolApi.Dtos.CourseDtos;

namespace SchoolApi.Validators.CourseValidators;

public class CourseToAddValidator: AbstractValidator<CourseToAddDto>
{
    public CourseToAddValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x=>x.TeacherId).NotEmpty().WithMessage("TeacherId cannot be empty");
    }
}