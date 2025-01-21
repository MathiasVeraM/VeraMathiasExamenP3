using VeraMathiasExamenP3.Interfaces;
using VeraMathiasExamenP3.Repositories;

namespace VeraMathiasExamenP3
{
    public partial class MainPage : ContentPage
    {
        private readonly IMVeraPeliculaAPI _mVeraPeliculaAPI;
        public MainPage(IMVeraPeliculaAPI mVeraPeliculaAPI)
        {
            InitializeComponent();
            _mVeraPeliculaAPI = mVeraPeliculaAPI;
        }

        private async void Buscar_Clicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            var data = await _mVeraPeliculaAPI.Obtener();
            listaPeliculas.ItemsSource = data;

            loading.IsVisible = false;
        }
    }

}
