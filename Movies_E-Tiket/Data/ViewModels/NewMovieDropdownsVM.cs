using Movies_E_Tiket.Models;


namespace Movies_E_Tiket.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }
    }
}