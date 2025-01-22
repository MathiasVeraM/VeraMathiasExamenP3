using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeraMathiasExamenP3.Models;

namespace VeraMathiasExamenP3.ViewModels
{
    public class MoviesDbViewModel : BindableObject
    {
        private ObservableCollection<MovieDb> _movies;

        public ObservableCollection<MovieDb> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }

        public MoviesDbViewModel()
        {
            Movies = new ObservableCollection<MovieDb>();
            LoadMovies();
        }

        private async void LoadMovies()
        {
            try
            {
                var movies = await App.Database.GetMoviesAsync();
                Movies = new ObservableCollection<MovieDb>(movies);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las películas: {ex.Message}");
            }
        }
    }
}
