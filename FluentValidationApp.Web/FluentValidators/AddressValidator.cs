using FluentValidation;
using UdemyCoreLibrary.Models;

namespace UdemyCoreLibrary.FluentValidators
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} can't be empty";
        public AddressValidator()
        {
            RuleFor(x=>x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMessage).
                MaximumLength(5).WithMessage("{PropertyName}  must be maximum {MaxLength} character");
        }
    }
}
