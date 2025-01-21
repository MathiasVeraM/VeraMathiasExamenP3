using VeraMathiasExamenP3.Interfaces;

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
            Cargando.IsVisible = true;
            var data = await _mVeraPeliculaAPI.Obtener();
            listaPeliculas.ItemsSource = data;

            Cargando.IsVisible = false;
        }
    }

}
