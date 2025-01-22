using VeraMathiasExamenP3.Models;
using VeraMathiasExamenP3.ViewModels;

namespace VeraMathiasExamenP3;

public partial class PeliculasBuscadas : ContentPage
{
	public PeliculasBuscadas()
	{
		InitializeComponent();
		BindingContext = new MoviesDbViewModel();
    }

    private async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedMovie = e.SelectedItem as MovieDb;
        if (selectedMovie != null)
        {
            await DisplayAlert("Película seleccionada", $"Título: {selectedMovie.Title}", "OK");
        }
    }
}