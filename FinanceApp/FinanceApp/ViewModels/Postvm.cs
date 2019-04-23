using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using FinanceApp.Annotations;
using FinanceApp.Models;
using FinanceApp.Services;
using Xamarin.Forms;

namespace FinanceApp.ViewModels
{
    public class PostVm : INotifyPropertyChanged
    {
        private Item _selectedPost;

        public event PropertyChangedEventHandler PropertyChanged;

        public Item SelectedPost
        {
            get => _selectedPost;
            set
            {
                _selectedPost = value;
                OnPropertyChanged(nameof(SelectedPost));
            }
        }

        public Command ShareCommand { get; set; }

        public PostVm()
        {
            SelectedPost = new Item();
            ShareCommand = new Command(Share);
        }

        public void Share()
        {
            var shareDependency = DependencyService.Get<IShare>();

            shareDependency.Show("Post from Finance", SelectedPost.ItemLink);
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
