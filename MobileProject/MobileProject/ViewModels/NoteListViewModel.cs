using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MobileProject.Models;
using MobileProject.Services;
using Xamarin.Forms;

namespace MobileProject.ViewModels
{
    public class NoteListViewModel : BindableObject
    {

        ObservableCollection<NoteItem> _items;

        public NoteListViewModel()
        {
            LoadShoppingList();
        }

        public ObservableCollection<NoteItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public void LoadShoppingList()
        {
            var items = NoteService.Instance.GetShoppingList();
            Items = new ObservableCollection<NoteItem>(items);
        }
    }
}