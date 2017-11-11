using Xamarin.Forms;

namespace Entry.Behaivor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Entry_BehaivorPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
