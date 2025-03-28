using GestorNotas1Q2025.Views;

namespace GestorNotas1Q2025
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainView());
        }
    }
}
