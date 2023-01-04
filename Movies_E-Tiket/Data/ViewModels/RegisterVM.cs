using System.ComponentModel.DataAnnotations;

namespace Movies_E_Tiket.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full_name")]
        [Required(ErrorMessage = "NameSurname_Required")]
        public string FullName { get; set; }

        [Display(Name = "Email_address")]
        [Required(ErrorMessage = "Email_required")]
        public string EmailAddress { get; set; }

        [Display(Name = "password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm_password")]
        [Required(ErrorMessage = "Confirmpassword_required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
