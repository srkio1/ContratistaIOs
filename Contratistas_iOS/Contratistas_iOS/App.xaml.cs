using Contratistas_iOS.Datos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Contratistas_iOS
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU5NjYxQDMxMzcyZTMzMmUzMFpacTFIMDFDTmw1TWhBL1haUy9FNS81Q0wyVjZjQ29lTDZvRFByTUp2WTg9");
            InitializeComponent();

            MainPage = new NavigationPage(new Splashpage());
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
