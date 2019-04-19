using FinanceApp.Models;
using FinanceApp.Views;
using Xamarin.Forms;

namespace FinanceApp.Behaviors
{
    public class ListViewBehavior : Behavior<ListView>
    {
        private ListView _listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            _listView = bindable;
            _listView.ItemSelected += ListViewOnItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);

            _listView.ItemSelected -= ListViewOnItemSelected;
        }

        private void ListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = _listView.SelectedItem as Item;

            Application.Current.MainPage.Navigation.PushAsync(new PostPage(selectedItem));
        }
    }
}
