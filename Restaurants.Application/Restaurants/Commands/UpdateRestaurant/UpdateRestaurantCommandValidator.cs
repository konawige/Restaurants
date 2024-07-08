using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator: AbstractValidator<UpdateRestaurantCommand>
{
    //private readonly List<string> _validCategories = ["Fast Food", "Traditional", "Italian", "Chinese", "Indian", "Mexican", "Vegetarian", "Vegan"];

    public UpdateRestaurantCommandValidator()
    {
        //RuleFor(x => x.Category).Must(x => _validCategories.Contains(x)).WithMessage("Invalid category");
        //RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Length(3, 100);
        //RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        //RuleFor(x => x.Category).NotEmpty();
        //RuleFor(x => x.HasDelivery).NotNull();
        //RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Please provide a valid email address");
        //RuleFor(x => x.PostalCode).Matches(@"^\d{2}-\d{3}$")
        //    .WithMessage("Please provide a valid postal code format (XX-XXX)");
        //how to check that we must specify either a phone number or an email address?
        //RuleFor(x => x.ContactNumber).NotEmpty().When(x => string.IsNullOrEmpty(x.ContactEmail))
        //    .WithMessage("Please provide a contact number or an email address");
    }
}