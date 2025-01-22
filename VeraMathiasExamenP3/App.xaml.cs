using VeraMathiasExamenP3.Repositories;

namespace VeraMathiasExamenP3
{
    public partial class App : Application
    {
        public static MovieDatabase Database { get; private set; }
        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mvera.db3");
            Database = new MovieDatabase(dbPath);

            MainPage = new AppShell();
        }
    }
}
