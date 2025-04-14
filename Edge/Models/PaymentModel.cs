using System.ComponentModel.DataAnnotations;

namespace Edge.Models
{
    public class PaymentModel
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; } = "ZAR";

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        // Credit Card Fields
        //[Display(Name = "Card Number")]
        //[CreditCard(ErrorMessage = "Invalid card number")]
        public string CardNumber { get; set; }

        [Display(Name = "Expiry Month")]
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12")]
        public int ExpiryMonth { get; set; }

        [Display(Name = "Expiry Year")]
        public int ExpiryYear { get; set; }

        [StringLength(4, MinimumLength = 3, ErrorMessage = "CVV must be 3 or 4 digits")]
        public string CVV { get; set; }

        [Display(Name = "Save Card")]
        public bool SaveCard { get; set; }

        public string ProductCode { get; set; } = "2221XFSE3";
    }

}