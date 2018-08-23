using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void Button_Clicked(object sender, EventArgs e)
        {
            greetingLabel.Text = "Welcome " + nameEntry.Text;
        }
    }
}
