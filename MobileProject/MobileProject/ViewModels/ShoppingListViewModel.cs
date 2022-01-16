using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MobileProject.Models;
using MobileProject.Services;
using Xamarin.Forms;

namespace MobileProject.ViewModels
{
    public class ShoppingListViewModel : BindableObject
    {

        ObservableCollection<ShoppingItem> _items;

        public ShoppingListViewModel()
        {
            LoadShoppingList();
        }

        public ObservableCollection<ShoppingItem> Items
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
            var items = ShoppingService.Instance.GetShoppingList();
            Items = new ObservableCollection<ShoppingItem>(items);
        }
    }
}