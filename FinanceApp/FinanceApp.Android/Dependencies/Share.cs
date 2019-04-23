using System.Threading.Tasks;
using Android.Content;
using FinanceApp.Droid.Dependencies;
using FinanceApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace FinanceApp.Droid.Dependencies
{
    public class Share : IShare
    {
        public Task Show(string title, string url)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            
            intent.PutExtra(Intent.ExtraText, url);
            intent.PutExtra(Intent.ExtraSubject, title);

            var chooserIntent = Intent.CreateChooser(intent, title);
            
            Android.App.Application.Context.StartActivity(chooserIntent);

            return Task.FromResult(true);
        }
    }
}