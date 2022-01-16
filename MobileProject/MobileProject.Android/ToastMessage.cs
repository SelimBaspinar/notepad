using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileProject.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage))]

namespace MobileProject.Droid
{
    public class ToastMessage : IMessage
    {
        public void ShortMessage(string mesaj)
        {
            Toast.MakeText(Android.App.Application.Context, mesaj, ToastLength.Short).Show();

        }

        public void LongMessage(string mesaj)
        {
            Toast.MakeText(Android.App.Application.Context, mesaj, ToastLength.Long).Show();
        }
    }
}