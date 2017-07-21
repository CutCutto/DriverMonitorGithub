using AppDriverMonitor.Controller;
using AppDriverMonitor.Tables;
using Newtonsoft.Json;
using Plugin.MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDriverMonitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Monitor : ContentPage
    {

        #region Propperties
        string ServiceAlarmURL = "http://my-first-web-cutto.azurewebsites.net/api/DriverStatus";
        private bool isProcessing = false;
        #endregion 
        public Monitor()
        {
            isProcessing = true;
            InitializeComponent();
            runTask();



            var Email = SessionController.DriverSessionValues.Email;

            if (SessionController.DriverSessionValues != null)
            {
                lblName.Text = string.Format("Hello :{0}", SessionController.DriverSessionValues.Email);
            }
        }

        public int CountTest = 0;

        private void runTask()
        {
            //var notification = new AlarmRun("1");

            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;

            // Start a new task (this launches a new thread)
            Task.Factory.StartNew(() =>
              {
                   // Do some work on a background thread, allowing the UI to remain responsive
                   lblName.Text = Convert.ToString(CountTest++);
                  checkAlarm();

                   // When the background work is done, continue with this code block
               }).ContinueWith(task =>
            {

                if (isProcessing)
                {
                    //runTask();
                }

                // the following forces the code in the ContinueWith block to be run on the
                // calling thread, often the Main/UI thread.
            }, TaskScheduler.FromCurrentSynchronizationContext());
            Task.Delay(5000);



        }

       async  private void checkAlarm()
        {
            string url = string.Format(ServiceAlarmURL + "/{0}", SessionController.DriverSessionValues.RefRegisterID);
            var client = new HttpClient();
            //HttpResponseMessage response = client.GetAsync(url).Result;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // Read Content as JSON String 
                var json = response.Content.ReadAsStringAsync().Result;

                // Convert JSON String to our MessageModel object, then return 
                var messageModel = JsonConvert.DeserializeObject<Tb_Trans_Driver_Status>(json);

                SessionController.DriverSessionStatus = messageModel;
                if (messageModel.Level == 1 || messageModel.Level == 2 || messageModel.Level == 3)
                {
                    isProcessing = false;
                   await Navigation.PushAsync(new PageAlarm());
                }

            }
            var ddd = string.Empty;
        }



        async private void btnSignOut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAlarm());
            //await Navigation.PopAsync();
        }


        async Task<string> GetTextAsync(CancellationToken ct)
        {
            // Check to see if task was cancelled; if so throw cancelled exception.
            // Good to check at several points, including just prior to returning the string.
            ct.ThrowIfCancellationRequested();

            // to simulate a task that takes variable amount of time
            await Task.Delay(5000);
            ct.ThrowIfCancellationRequested();
            string url = string.Format(ServiceAlarmURL + "/{0}", SessionController.DriverSessionValues.RefRegisterID);
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                // Read Content as JSON String 
                var json = response.Content.ReadAsStringAsync().Result;

                // Convert JSON String to our MessageModel object, then return 
                var messageModel = JsonConvert.DeserializeObject<Tb_Trans_Driver_Status>(json);

                SessionController.DriverSessionStatus = messageModel;
                if (messageModel.Level > 0)
                {
                    isProcessing = false;
                    await Navigation.PushAsync(new PageAlarm());
                }
                else
                {
                    await GetTextAsync(ct);
                }

            }

            ct.ThrowIfCancellationRequested();
            return string.Empty;
        }


    }
}