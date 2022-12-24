using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Movies_E_Tiket.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage =("Profile Picture is required"))]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(50,MinimumLength =3,ErrorMessage =("The Full Name must be between 3 and 50 Characters"))]  
        [Required(ErrorMessage = ("Full Name is required"))]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = ("Biography is required"))]
        public string Bio { get; set; }
        //Relationship

        [ValidateNever]
        public List<Actor_Movie> Actors_Movies  { get; set; }

    }
}
