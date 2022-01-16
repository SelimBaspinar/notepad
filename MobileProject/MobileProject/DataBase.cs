using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileProject
{
    internal class DataBase
    {
         SQLiteConnection reminderdb;
        SQLiteConnection reminderitemdb;

        public void Init()
        {
            if (reminderdb != null || reminderitemdb != null)
                return;
            var reminderdbPath = Path.Combine(FileSystem.AppDataDirectory, "Reminder.db");
            var reminderitemdbPath = Path.Combine(FileSystem.AppDataDirectory, "ReminderItem.db");
            reminderdb = new SQLiteConnection(reminderdbPath);
            reminderdb.CreateTable<ReminderDB>();
            reminderitemdb = new SQLiteConnection(reminderitemdbPath);
            reminderitemdb.CreateTable<ReminderItemDB>();
 
        }
    
   
        public void AddReminder( string name, string color,string icon)
        {
             Init();
            var reminder = new ReminderDB()
            {
                Name = name,
                Color = color,
                Icon=icon,
            };
            var id = reminderdb.Insert(reminder);
        }
      

        public void RemoveReminder()
        {
            Init();

            reminderdb.DeleteAll<ReminderDB>();
        }
        public void RemoveReminderId(int id)
        {
            Init();
            var existingReminder = reminderdb.Query<ReminderDB>("select * from ReminderDB where Id = ?", id)[0];
            if (existingReminder != null)
            {
                reminderdb.Delete(existingReminder);
            }
        }
        public void RemoveReminder(object item)
        {
            Init();

            var id = reminderdb.Delete(item);

        }

        public List<ReminderDB> GetReminder()
        {
            Init();
            var reminder = reminderdb.Table<ReminderDB>().ToList();

            return reminder;
        }
       
        public void AddReminderItem(string name, string color,  bool islatest,int reminderid,bool isdone,string isdoneimg)
        {
            Init();
            var reminderitem = new ReminderItemDB()
            {
                Name = name,
                Color = color,
                IsLatest = islatest,
                IsDone=isdone,
                IsDoneImg=isdoneimg,
                ReminderId=reminderid,
            };
            var id = reminderitemdb.Insert(reminderitem);
        }
        public void UpdateReminderItem(int id,bool isdone,string isdoneimg)
        {
            Init();
 

            var existingReminderItem = reminderitemdb.Query<ReminderItemDB>("select * from ReminderItemDB where Id = ?",id)[0];
            if (existingReminderItem != null)
            {
                existingReminderItem.IsDone = isdone;
                existingReminderItem.IsDoneImg = isdoneimg;

                reminderitemdb.Update(existingReminderItem);
            }


        }
        public void RemoveReminderItem()
        {
            Init();

            reminderitemdb.DeleteAll<ReminderItemDB>();
        }
        public void RemoveReminderItemId(int id)
        {
            Init();
            var existingReminderItem = reminderitemdb.Query<ReminderItemDB>("select * from ReminderItemDB where ReminderId = ?", id)[0];
            if (existingReminderItem != null)
            {
                reminderitemdb.Delete(existingReminderItem);
            }
        }
        public void RemoveReminderItem(object item)
        {
            Init();

            var id = reminderitemdb.Delete(item);

        }

        public List<ReminderItemDB> GetReminderItem()
        {
            Init();
            var reminderitem = reminderitemdb.Table<ReminderItemDB>().ToList();

            return reminderitem;
        }


    }
}
