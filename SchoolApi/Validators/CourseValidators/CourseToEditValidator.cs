using FluentValidation;
using SchoolApi.Dtos.CourseDtos;

namespace SchoolApi.Validators.CourseValidators;

public class CourseToEditValidator: AbstractValidator<CourseToEditDto>
{
    public CourseToEditValidator()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x=>x.TeacherId).NotEmpty().WithMessage("TeacherId cannot be empty");
    }
}