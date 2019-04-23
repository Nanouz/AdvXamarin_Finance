using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceApp.Models;
using FinanceApp.ViewModels;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        //public Item Item { get; }

        private PostVm _viewModel;

        public PostPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        public PostPage(Item item)
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);

            _viewModel = Resources["Vm"] as PostVm;
            _viewModel.SelectedPost = item;

            try
            {
                //throw (new Exception("Unable to load blog"));
                //WebView.Source = item.ItemLink;

                Title = item.Title;
                PostImage.Source = item.Enclosure.Url;
                CreatorLabel.Text = item.Creator;
                DateLabel.Text = item.PublishedDate.ToString("MMMM dd");
                DescriptionLabel.Text = item.Description;

                var properties = new Dictionary<string, string>
                {
                    { "Blog_Post", $"{item.Title}" }
                };

                TrackEvent(properties);
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "Blog_Post", $"{item.Title}" }
                };

                //Crashes.TrackError(ex, properties);
                TrackError(ex, properties);
            }
        }

        private async void TrackEvent(Dictionary<string, string> properties)
        {
            if (await Analytics.IsEnabledAsync())
                Analytics.TrackEvent("Blog_Post_Opened", properties);
        }

        private async void TrackError(Exception ex, Dictionary<string, string> properties)
        {
            if (await Crashes.IsEnabledAsync())
                Crashes.TrackError(ex, properties);
        }
    }
}