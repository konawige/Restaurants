using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.DTOs;

public class CreateRestaurantDto
{
    //[StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = default!;
    
    public string Description { get; set; } = default!;
    
    //[Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = default!;
    
    public bool HasDelivery { get; set; } = default!;
    //[EmailAddress(ErrorMessage = "Invalid email address")]
    public string? ContactEmail { get; set; }
    
    //[Phone(ErrorMessage = "Invalid phone number")]
    public string? ContactNumber { get; set; }
    
    public string? Street { get; set; }
    public string? City { get; set; }
    
    //[RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Proper postal code format is XX-XXX")]
    public string? PostalCode { get; set; }
    
}