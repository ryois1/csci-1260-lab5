namespace Lab5.Data;

public class MovieService : IMovieService
{
    public List<Movie> ReadFromFile()
    {
        List<Movie> movies = new List<Movie>();
        string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
        string file = "movies.psv";
        string fullPath = Path.Combine(rootpath, file);
        using (StreamReader sr = new StreamReader(fullPath))
        {
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[]? data = line.Split('|');
                    string title = data[0];
                    int year = Int32.Parse(data[1]);
                    string genre = data[2];
                    movies.Add(new Movie(title, year, genre));
                }

            }
        }
        return movies;
    }

    public List<Movie> GetMovies(Func<Movie, bool> filter)
    {
        var movies = ReadFromFile();
        return movies.Where(filter).ToList();
    }

    public void AddMovie(Movie movie)
    {
        System.Console.WriteLine("Adding movie to file");
        try
        {
            string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
            string file = "movies.psv";
            string fullPath = Path.Combine(rootpath, file);
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine($"{movie.Title}|{movie.Year}|{movie.Genre}");
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

    }
}