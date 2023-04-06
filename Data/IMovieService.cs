namespace Lab5.Data
{
    public interface IMovieService
    {
        List<Movie> ReadFromFile();
        List<Movie> GetMovies(Func<Movie, bool> filter);
        void AddMovie(Movie movie);
    }
}