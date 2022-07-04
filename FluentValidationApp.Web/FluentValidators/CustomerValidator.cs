using FluentValidation;
using UdemyCoreLibrary.FluentValidators;
using UdemyCoreLibrary.Models;

namespace UdemyCoreLibrary.FluentValidator
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} can't be empty";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Enail should be correct format");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage)
                .InclusiveBetween(18, 60).WithMessage("Age must be 18 and 60 range");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18)>= x;
            }).WithMessage("Your age must be more than 18");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("{Property name} must be 1 for male and 2 for female");
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
    }
}
