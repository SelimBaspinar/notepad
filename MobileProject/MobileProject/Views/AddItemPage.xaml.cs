using MobileProject.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        DataBase data = new DataBase();
        ObservableCollection<Items> list = new ObservableCollection<Items>();

        public AddItemPage()
        {
            InitializeComponent();
            colorpicker.SelectedIndex = 0;
            classpicker.SelectedIndex = 0;

        }
        public async void golist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingListView());
        }
        public async void deleteinvoke(object sender, EventArgs e)
        {
            var item = (SwipeItem)sender;
            var list1 = item.CommandParameter;
            list.Remove((Items)list1);
        }
        void SelectedDate(object sender, DateChangedEventArgs args)
        {


            String myDate = DateTime.Now.ToString();
        }
        public async void savedata(object sender, EventArgs e)
        {
            if (list.Count!=0)
            {
                string color = "Green";
                string icon = "reminder.png";
                if (colorpicker.Items[colorpicker.SelectedIndex].ToString() == "Urgent")
                    color = "Red";
                else if (colorpicker.Items[colorpicker.SelectedIndex].ToString() == "Important")
                    color = "Orange";
                else
                    color = "Green";

                if (classpicker.Items[classpicker.SelectedIndex].ToString() == "Fun")
                    icon = "fun.png";
                else if (classpicker.Items[classpicker.SelectedIndex].ToString() == "Lecture")
                    icon = "lecture.png";
                else if (classpicker.Items[classpicker.SelectedIndex].ToString() == "Travel")
                    icon = "travel.png";
                else if (classpicker.Items[classpicker.SelectedIndex].ToString() == "Market")
                    icon = "market.png";
                else
                    icon = "reminder.png";

                string name = nameentry.Text + "-" + DatePicker.Date.ToShortDateString();
                data.AddReminder(name, color, icon);

                var lastreminder = data.GetReminder().Last();

                foreach (var item in list)
                {
                    data.AddReminderItem(item.Name, "Green", false, lastreminder.Id, false, "add.png");
                }



                DependencyService.Get<IMessage>().ShortMessage("Reminder is Created!");
                await Task.Run(() => Thread.Sleep(1000));
                await Navigation.PushAsync(new ShoppingListView());


            }
            else
            {
                DependencyService.Get<IMessage>().ShortMessage("Please Add Item");
            }




        }
        public async void additem(object sender, EventArgs e)
        {


            list.Add(new Items() {Name= itementry.Text });   

            DependencyService.Get<IMessage>().ShortMessage("Item Added!");
            itemlistview.ItemsSource = list;





        }
    }
}
