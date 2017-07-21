using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDriverMonitor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //image.Source = ImageSource.FromResource("AppDriverMonitor.Pictures.facebook.png");


        }

        async private void bntRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        async private void btnSignIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}
