using MobileProject.Models;
using MobileProject.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileProject.Views
{
    public partial class ShoppingListView : ContentPage
    {
        public ShoppingListView()
        {
            InitializeComponent();

        }
        DataBase db = new DataBase();

        public async void deleteinvoke(object sender, EventArgs e)
        {
                var item = (SwipeItem)sender;
                var list1 = (NoteItem)item.CommandParameter;

            db.RemoveReminderId(list1.Id);
            db.RemoveReminderItemId(list1.Id);

          
            NoteListViewModel shoppingListViewModel = new NoteListViewModel();
            this.BindingContext = shoppingListViewModel;





        }
        public async void ChangeDoneStat(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            Console.WriteLine("imageid:" + image.Source.ToString());

            if (image.Source.ToString() == "File: ok.png")
                image.Source = "add.png";
            else
                image.Source = "ok.png";

            List<ReminderItemDB> reminderitem = db.GetReminderItem();
            List<ReminderDB> reminder= db.GetReminder();
            reminderitem.ForEach(x =>
            {

                if (image.ClassId == x.Id.ToString())
                {

                    if (x.IsDoneImg == "ok.png")
                        db.UpdateReminderItem(x.Id, !x.IsDone, "add.png");
                    else
                        db.UpdateReminderItem(x.Id, !x.IsDone, "ok.png");

                }

            });
            reminderitem = db.GetReminderItem();
            reminder.ForEach(x => {
                int count = 0;
                var filterrenderitem = new List<ReminderItemDB>();
                reminderitem.ForEach(y => {
                    if (x.Id == y.ReminderId)
                    {
                        filterrenderitem.Add(y);
                        if (y.IsDone == true)
                        {
                            count++;
                        }

                    }
                });
                Console.WriteLine("asdcount:"+filterrenderitem.Count);
                Console.WriteLine("asdcount1:" + count);

                if (count == filterrenderitem.Count)
                {
                    db.RemoveReminder(x);
                    filterrenderitem.ForEach(z => {
                        db.RemoveReminderItem(z);
                    });
                    NoteListViewModel shoppingListViewModel = new NoteListViewModel();
                    this.BindingContext = shoppingListViewModel;
                }
            });



        }
    }
}
