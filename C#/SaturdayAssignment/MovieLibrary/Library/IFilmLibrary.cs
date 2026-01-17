using System.Collections.Generic;
using MovieLibraryApp.Models;
namespace MovieLibraryApp.Library
{
    public interface IFilmLibrary
    {
        void AddFilm(Film film);
        void RemoveFilm(string title);
        List<Film> GetFilms();
        List<Film> Search(string query);
    }
}