using Quezada_Evaluacion3P.Services;
using System.IO;

namespace Quezada_Evaluacion3P
{
    public partial class App : Application
    {
        static AQSevicioDatabase database;

        public static AQSevicioDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AQSevicioDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AQGames.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}