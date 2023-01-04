using System.ComponentModel.DataAnnotations;

namespace Movies_E_Tiket.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email_address")]
        [Required(ErrorMessage = "Emailaddressrequired")]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
