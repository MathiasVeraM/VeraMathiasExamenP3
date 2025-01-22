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
        private ObservableCollection<Movie> _movies;

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadMoviesCommand { get; }

        public MovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            LoadMoviesCommand = new Command(async () => await LoadMoviesAsync());
            Task.Run(() => LoadMoviesAsync());
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
