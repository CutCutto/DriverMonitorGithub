using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppDriverMonitor;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Media;
using AppDriverMonitor.Droid;
using Android.Content.Res;
using AppDriverMonitor.Controller;

[assembly: ExportRenderer(typeof(PageAlarm), typeof(AlarmRenderer))]
namespace AppDriverMonitor.Droid
{
    public class AlarmRenderer : PageRenderer
    {
        public PageAlarm page;
        public Android.Views.View view;
        public MediaPlayer _player;
        public AlarmRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);


            page = e.NewElement as PageAlarm;
            var activity = Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.Alarm, this, false);
            var playButton = view.FindViewById<Android.Widget.Button>(Resource.Id.playButton);

            _player = MediaPlayer.Create(activity, Resource.Raw.test);
            _player.Start();


            playButton.Text += " Level " + SessionController.DriverSessionStatus.Level;
            playButton.SetBackgroundColor(Android.Graphics.Color.Red);
            playButton.Click += delegate
            {

                
                if (_player.IsPlaying)
                {
                    _player.Stop();
                }
                page.Navigation.PopAsync();
                
            };

            AddView(view);

        }


        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }

    }
}