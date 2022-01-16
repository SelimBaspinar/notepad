using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileProject
{
    internal class List : ObservableCollection<Items>
    {

        public List(string name) : base()
        {


            Add(new Items() { Name = name }) ;
           


        }

    }
}
