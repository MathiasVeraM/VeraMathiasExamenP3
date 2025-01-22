using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using VeraMathiasExamenP3.Models;
using SQLite;
using VeraMathiasExamenP3.Repositories;

namespace VeraMathiasExamenP3.ViewModels
{
    public class MovieViewModel : BindableObject
    {
        private ObservableCollection<Movie> _movies;
        private string _searchQuery;

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public Command SearchCommand { get; }

        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            SearchCommand = new Command(async () => await SearchMoviesAsync());
        }

        private async Task SearchMoviesAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese un título para buscar.", "OK");
                return;
            }

            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync($"https://freetestapi.com/api/v1/movies?search={Uri.EscapeDataString(SearchQuery)}");

                if (response.IsSuccessStatusCode)
                {
                    var movies = await response.Content.ReadFromJsonAsync<List<Movie>>();
                    if (movies != null && movies.Count > 0)
                    {
                        foreach (var movie in movies)
                        {
                            var movieDb = new MovieDb
                            {
                                Title = movie.Title,
                                Genre = movie.Genre.Length > 0 ? movie.Genre[0] : "Desconocido",
                                MainActor = movie.Actors.Length > 0 ? movie.Actors[0] : "Desconocido",
                                Awards = movie.Awards ?? "N/A", 
                                Website = movie.Website ?? "N/A", 
                                MVera = "MVera"
                            };

                            await App.Database.SaveMovieAsync(movieDb);
                        }

                        Movies = new ObservableCollection<Movie>(movies);
                    }
                    else
                    {
                        Movies.Clear();
                        await Application.Current.MainPage.DisplayAlert("Sin resultados", "No se encontraron películas con ese título.", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Error al buscar películas: {response.ReasonPhrase}", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}
