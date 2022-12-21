namespace Movies_E_Tiket.Models
{
    public class Cinemas_Movies
    {
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
