using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using FinanceApp.Models;

namespace FinanceApp.ViewModels
{
    public class MainVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Post Post { get; set; }

        public MainVm()
        {
            ReadRss();
        }

        public void ReadRss()
        {
            var serializer = new XmlSerializer(typeof(Post));

            using (var client = new WebClient())
            {
                var xml = Encoding.Default.GetString(client.DownloadData("https://www.finzen.mx/blog-feed.xml"));

                using (var reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    Post = (Post) serializer.Deserialize(reader);
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
