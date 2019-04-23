using System;
using FinanceApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FinanceApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            // Handle when your app starts

            var androidAppSecret = "d276f05c-1c51-4075-a24b-ba7eb1536e6a";
            var iOSAppSecret = "d666b608-0803-4da9-8cb6-ff32ce594ada";

            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}", typeof(Crashes), typeof(Analytics));

            var isAppCrashed = await Crashes.HasCrashedInLastSessionAsync();
            if (isAppCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }
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
