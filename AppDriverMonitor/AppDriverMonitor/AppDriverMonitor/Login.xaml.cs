using AppDriverMonitor.Controller;
using AppDriverMonitor.Tables;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDriverMonitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        #region Properties
        string ServiceLogInURL = "http://my-first-web-cutto.azurewebsites.net/api/Tb_DriverRegister/";
        #endregion
        public Login()
        {
            InitializeComponent();
        }

        async private void btnSignIn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(enEmail.Text.Trim()) && !string.IsNullOrEmpty(enPassword.Text.Trim()))
            {
                //Call Web API  Login
                string url = string.Format(ServiceLogInURL+"{0}/{1}",enEmail.Text.Trim(),enPassword.Text.Trim());
                var client = new HttpClient();



                //var response = await client.GetAsync(url).Result;

                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Read Content as JSON String 
                    var json = response.Content.ReadAsStringAsync().Result;

                    // Convert JSON String to our MessageModel object, then return 
                    var messageModel = JsonConvert.DeserializeObject<Tb_DriverRegister>(json);

                    SessionController.DriverSessionValues = messageModel;
                    await Navigation.PushAsync(new Monitor());



                }
                else
                {
                    await DisplayAlert("Login", "Please check Email or Password.", "OK");
                }
                var ddd = string.Empty;
            }
            else
            {
                
            }
            
        }
    }
}