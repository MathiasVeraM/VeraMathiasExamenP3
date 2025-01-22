using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VeraMathiasExamenP3.Models;

namespace VeraMathiasExamenP3.ViewModels
{
    public class MovieViewModel : BindableObject
    {
        private string _searchQuery;
        private ObservableCollection<Movie> _movies;
        private ObservableCollection<Movie> _filteredMovies;

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterMovies();
            }
        }

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Movie> FilteredMovies
        {
            get => _filteredMovies;
            set
            {
                _filteredMovies = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadMoviesCommand { get; }

        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            FilteredMovies = new ObservableCollection<Movie>();
            LoadMoviesCommand = new Command(async () => await LoadMoviesAsync());
        }

        private async Task LoadMoviesAsync()
        {
            try
            {
                using var client = new HttpClient();
                var movies = await client.GetFromJsonAsync<List<Movie>>("https://freetestapi.com/api/v1/movies?");
                if (movies != null)
                {
                    Movies = new ObservableCollection<Movie>(movies);
                    FilterMovies();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void FilterMovies()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredMovies = new ObservableCollection<Movie>(Movies);
            }
            else
            {
                FilteredMovies = new ObservableCollection<Movie>(
                Movies.Where(m => m.Title.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)));
            }
        }
    }
}
