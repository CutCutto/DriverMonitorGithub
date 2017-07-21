using AppDriverMonitor.Controller;
using AppDriverMonitor.Tables;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDriverMonitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        #region Propperties
        string KeyFace_API = "b0f5abfb6c31462088f5722de04e54bc";
        string UrlFace_API = "https://southeastasia.api.cognitive.microsoft.com/face/v1.0";
        string ServiceRegisterURL = "http://my-first-web-cutto.azurewebsites.net/api/Tb_DriverRegister";
        Byte[] imgByte; 
        #endregion

        public AllRegister registerValue;

        public Register()
        {
            InitializeComponent();


        }


        async private void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (imageShow.Source != null)
            {
                registerValue.regis = new Tb_DriverRegister();
                registerValue.regis.RegisterName = enUserName.Text.Trim();
                registerValue.regis.Email = enEmail.Text.Trim();
                registerValue.regis.Password = enPassword.Text.Trim();
                registerValue.regis.Tel = enTel.Text.Trim();
                /*
                //Call Web API  Register
                string url = ServiceRegisterURL;
                string contentType = "application/json"; // or application/xml

                // Create JObject instance as 'jsonObject', then Add( "key" , value);
                JObject jsonObject = new JObject();
                jsonObject.Add("RegisterName", registerValue.RegisterName);
                jsonObject.Add("Email", registerValue.Email);
                jsonObject.Add("Password", registerValue.Password);
                jsonObject.Add("Tel", registerValue.Tel);



                StringContent content = new StringContent(jsonObject.ToString(), Encoding.UTF8, contentType);
                var client = new HttpClient();
                var response = await client.PostAsync(url, content);


                await DisplayAlert("Register", "Register Complate", "OK");
                await Navigation.PopAsync();
                */
                //convert it to JSON acceptible content 

                string url = ServiceRegisterURL;
                string jsonRegister = JsonConvert.SerializeObject(registerValue);
                HttpContent content = new StringContent(jsonRegister, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                var response = await client.PostAsync(url, content);
                await DisplayAlert("Register", "Register Complate", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Register", "Please task photo", "OK");
            }
        }

        async private void btnTakePhoto_Clicked(object sender, EventArgs e)
        {

            try
            {
                // Init
                await CrossMedia.Current.Initialize();

                // Check Is-Camera-Available and Is-Take-Photo-Support?
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                // get file from TakePhotoAsync with Plugin.Media.Abstractions.StoreCameraMediaOptions{ Directory & Name }
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg",
                    PhotoSize = PhotoSize.Medium,
                    DefaultCamera = CameraDevice.Front
                });

                // Check if file is null
                if (file == null)
                    return;

                // Show file.Path in DisplayAlert
                await DisplayAlert("File Location", file.Path, "OK");

                // Use ImageSource.FromStream to show file in image.Source
                var streamPic = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    //file.Dispose();
                    return stream;
                });

                //Convert Byte
                /*
                byte[] buffer = new byte[(1024 * 1024)*10];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = file.GetStream().Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    imgByte= ms.ToArray();
                }
                */


                //await  
                using (var stream = file.GetStream())
                {
                    var client = new FaceServiceClient(KeyFace_API, UrlFace_API);
                    var faces = await client.DetectAsync(stream, true, true);
                    var attFace = faces.FirstOrDefault();

                    if (attFace != null)
                    {
                        AllRegister registerValueActivities = new AllRegister();
                        Calculate cal = new Calculate();
                        
                        #region Mouth
                        /// Mouth
                        if (attFace.FaceLandmarks != null)
                        {
                            registerValueActivities.mouth = new Tb_Mouth();
                            registerValueActivities.mouth.MouthLeft_X = attFace.FaceLandmarks.MouthLeft.X;
                            registerValueActivities.mouth.MouthLeft_Y = attFace.FaceLandmarks.MouthLeft.Y;
                            registerValueActivities.mouth.MouthRight_X = attFace.FaceLandmarks.MouthRight.X;
                            registerValueActivities.mouth.MouthRight_Y = attFace.FaceLandmarks.MouthRight.Y;
                            registerValueActivities.mouth.UpperLipBottom_X = attFace.FaceLandmarks.UpperLipBottom.X;
                            registerValueActivities.mouth.UpperLipBottom_Y = attFace.FaceLandmarks.UpperLipBottom.Y;
                            registerValueActivities.mouth.UnderLipBottom_X = attFace.FaceLandmarks.UnderLipBottom.X;
                            registerValueActivities.mouth.UnderLipBottom_Y = attFace.FaceLandmarks.UnderLipBottom.Y;
                            registerValueActivities.mouth.UpperLipTop_X = attFace.FaceLandmarks.UpperLipTop.X;
                            registerValueActivities.mouth.UpperLipTop_Y = attFace.FaceLandmarks.UpperLipTop.Y;
                            registerValueActivities.mouth.UnderLipTop_X = attFace.FaceLandmarks.UnderLipTop.X;
                            registerValueActivities.mouth.UnderLipTop_Y = attFace.FaceLandmarks.UnderLipTop.Y;
                            registerValueActivities.mouth.MouthAperture = cal.CalMouth(attFace.FaceLandmarks.MouthRight.X
                                                                                        , attFace.FaceLandmarks.MouthLeft.X
                                                                                        , attFace.FaceLandmarks.UpperLipBottom.Y
                                                                                        , attFace.FaceLandmarks.UnderLipTop.Y);
                        }


                        #endregion

                        #region Head
                        if (attFace.FaceAttributes != null)
                        {
                            registerValueActivities.head = new Tb_Head();
                            registerValueActivities.head.HeadPost_Pitch = attFace.FaceAttributes.HeadPose.Pitch;
                            registerValueActivities.head.HeadPost_Roll = attFace.FaceAttributes.HeadPose.Roll;
                            registerValueActivities.head.HeadPost_Yaw = attFace.FaceAttributes.HeadPose.Yaw;
                            registerValueActivities.head.HeadPost_PoseDeviation = cal.CalHead(attFace.FaceAttributes.HeadPose.Yaw);
                        }
                        #endregion

                        #region Eyes
                        //Left
                        if (attFace.FaceLandmarks != null)
                        {
                            registerValueActivities.eye = new Tb_Eye();
                            registerValueActivities.eye.EyeLeftInner_X = attFace.FaceLandmarks.EyeLeftInner.X;
                            registerValueActivities.eye.EyeLeftInner_Y = attFace.FaceLandmarks.EyeLeftInner.Y;

                            registerValueActivities.eye.EyeLeftBottom_X = attFace.FaceLandmarks.EyeLeftBottom.X;
                            registerValueActivities.eye.EyeLeftBottom_Y = attFace.FaceLandmarks.EyeLeftBottom.Y;

                            registerValueActivities.eye.EyeLeftOuter_X = attFace.FaceLandmarks.EyeLeftOuter.X;
                            registerValueActivities.eye.EyeLeftOuter_Y = attFace.FaceLandmarks.EyeLeftOuter.Y;

                            registerValueActivities.eye.EyeLeftTop_X = attFace.FaceLandmarks.EyeLeftTop.X;
                            registerValueActivities.eye.EyeLeftTop_Y = attFace.FaceLandmarks.EyeLeftTop.Y;

                            //Right
                            registerValueActivities.eye.EyeRightInner_X = attFace.FaceLandmarks.EyeRightInner.X;
                            registerValueActivities.eye.EyeRightInner_Y = attFace.FaceLandmarks.EyeRightInner.Y;

                            registerValueActivities.eye.EyeRightBottom_X = attFace.FaceLandmarks.EyeRightBottom.X;
                            registerValueActivities.eye.EyeRightBottom_Y = attFace.FaceLandmarks.EyeRightBottom.Y;

                            registerValueActivities.eye.EyeRightOuter_X = attFace.FaceLandmarks.EyeRightOuter.X;
                            registerValueActivities.eye.EyeRightOuter_Y = attFace.FaceLandmarks.EyeRightOuter.Y;

                            registerValueActivities.eye.EyeRightTop_X = attFace.FaceLandmarks.EyeRightTop.X;
                            registerValueActivities.eye.EyeRightTop_Y = attFace.FaceLandmarks.EyeRightTop.Y;
                            registerValueActivities.eye.EyeRightTop_Y = cal.CalEyes(attFace.FaceLandmarks.EyeLeftInner.X
                                , attFace.FaceLandmarks.EyeLeftOuter.X
                                , attFace.FaceLandmarks.EyeLeftBottom.Y
                                , attFace.FaceLandmarks.EyeLeftTop.Y
                                , attFace.FaceLandmarks.EyeRightInner.X
                                , attFace.FaceLandmarks.EyeRightOuter.X
                                , attFace.FaceLandmarks.EyeRightBottom.Y
                                , attFace.FaceLandmarks.EyeRightTop.Y);
                        }
                        #endregion
                        
                        registerValue = registerValueActivities;

                    }
                    else
                    {
                        await DisplayAlert("Take Photo", "Please Re Take Photo", "OK");
                        return;
                    }
                }

                imageShow.Source = streamPic;
            }
            catch (Exception ex)
            {
                var ddd = ex.Message;
            }
        }

        /*
        async private void btnTest_Clicked(object sender, EventArgs e)
        {

            string url = ServiceRegisterURL;
            string contentType = "application/json"; // or application/xml

            JObject job1 = new JObject();
            JObject job2 = new JObject();
            JObject job3 = new JObject();
            JObject job4 = new JObject();

            job2.Add("RegisterName", "T01");
            job3.Add("EyeLeftInner_X", 01.22);



            job1.Add("regis", job2);
            job1.Add("eye", job3);
            job1.Add("head", job4);

            StringContent content = new StringContent(job1.ToString(), Encoding.UTF8, contentType);
            var client = new HttpClient();
            var response = await client.PostAsync("http://my-first-web-cutto.azurewebsites.net/api/Tb_Dri", content);


            await DisplayAlert("Register", "Register Complate", "OK");
        }
        */
    }
}