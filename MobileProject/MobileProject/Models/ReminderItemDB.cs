using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileProject
{
    public class ReminderItemDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsLatest { get; set; }
        public bool IsDone { get; set; }
        public int ReminderId { get; set; }
        public string IsDoneImg { get; set; }

    }

}
