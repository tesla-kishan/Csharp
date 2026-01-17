// using System;
// using MovieLibraryApp.Models;
// using MovieLibraryApp.Library;

// namespace MovieLibraryApp
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             FilmLibrary library = new FilmLibrary();

//             library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
//             library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
//             library.AddFilm(new Film("3 Idiots", "Rajkumar Hirani", 2009));

//             Console.WriteLine("🎬 All Films:");
//             Display(library.GetFilms());

//             Console.WriteLine("\n🔍 Search Result for 'Nolan':");
//             Display(library.Search("Nolan"));

//             library.RemoveFilm("3 Idiots");

//             Console.WriteLine("\n📂 Films After Removal:");
//             Display(library.GetFilms());
//         }

//         static void Display(System.Collections.Generic.List<Film> films)
//         {
//             foreach (var film in films)
//             {
//                 Console.WriteLine($"Title: {film.Title}, Director: {film.Director}, Year: {film.Year}");
//             }
//         }
//     }
// }