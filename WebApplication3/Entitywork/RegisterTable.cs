using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Entitywork
{
    public class RegisterTable
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty; // Default to an empty string

        [Required(ErrorMessage = "Age is required.")]
        public string Age { get; set; } = string.Empty; // Default to an empty string

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty; // Default to an empty string

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty; // Default to an empty string

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty; // Default to an empty string

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; } = string.Empty; // Default to an empty string

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty; // Default to an empty string

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        public string ConPassword { get; set; } = string.Empty; // Default to an empty string
    }
}
