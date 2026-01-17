using System;
using System.Collections.Generic;
using System.Linq;
using MovieLibraryApp.Models;

namespace MovieLibraryApp.Library
{
    public class FilmLibrary : IFilmLibrary
    {
        private List<Film> films = new List<Film>();

        public void AddFilm(Film film)
        {
            films.Add(film);
        }

        public void RemoveFilm(string title)
        {
            var film = films.FirstOrDefault(f =>
                f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (film != null)
                films.Remove(film);
            else
                Console.WriteLine("Film not found!");
        }
        // public void RemoveFilm(string title)
        // {
        //     Film filmToRemove = null;

        //     foreach (Film f in films)
        //     {
        //         if (f.Title == title)
        //         {
        //             filmToRemove = f;
        //             break;
        //         }
        //     }

        //     if (filmToRemove != null)
        //         films.Remove(filmToRemove);
        //     else
        //         Console.WriteLine("Film not found!");
        // }

        public List<Film> GetFilms()
        {
            return films;
        }

        public List<Film> Search(string query)
        {
            return films.Where(f =>
                f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                f.Director.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                f.Year.ToString().Contains(query)
            ).ToList();
        }
    }
}