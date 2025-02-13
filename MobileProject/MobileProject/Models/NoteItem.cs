﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileProject.Models
{
    public class NoteItem : BindableObject
    {
        bool _isDetailVisible;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public Color Color { get; set; }

        public bool IsDetailVisible
        {
            get { return _isDetailVisible; }
            set
            {
                Task.Run(async () =>
                {
                    await Task.Delay(value ? 0 : 250);
                    _isDetailVisible = value;
                    OnPropertyChanged();
                });
            }
        }

        public List<NoteDetailItem> Items { get; set; }
    }

    public class NoteDetailItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public bool Done { get; set; }
        public bool IsLatest { get; set; }
        public int ReminderId { get; set; }
        public string IsDoneImg { get; set; }  
    }
}