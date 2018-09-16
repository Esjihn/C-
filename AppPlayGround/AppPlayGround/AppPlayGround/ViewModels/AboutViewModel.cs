using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace AppPlayGround.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.google.com")));
        }

        public ICommand OpenWebCommand { get; }
    }
}