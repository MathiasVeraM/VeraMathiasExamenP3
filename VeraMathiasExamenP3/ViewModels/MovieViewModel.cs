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
                var response = await client.GetStringAsync($"https://freetestapi.com/api/v1/movies?search={Uri.EscapeDataString(SearchQuery)}");

                if (string.IsNullOrWhiteSpace(response))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se recibieron datos de la API.", "OK");
                    return;
                }

                var movies = JsonSerializer.Deserialize<List<Movie>>(response);

                if (movies == null || movies.Count == 0)
                {
                    Movies.Clear();
                    await Application.Current.MainPage.DisplayAlert("Sin resultados", "No se encontraron películas con ese título exacto.", "OK");
                }
                else
                {
                    var filteredMovies = movies.Where(m => m.Title.Equals(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (filteredMovies.Count > 0)
                    {
                        Movies = new ObservableCollection<Movie>(filteredMovies);
                    }
                    else
                    {
                        Movies.Clear();
                        await Application.Current.MainPage.DisplayAlert("Sin resultados", "No se encontraron películas con ese título exacto.", "OK");
                    }
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
