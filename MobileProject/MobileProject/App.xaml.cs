using MobileProject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CustomNavigationPage(new ShoppingListView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
