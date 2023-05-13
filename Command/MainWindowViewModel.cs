using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace Command
{
    public class MainWindowViewModel : ViewModelBase
    {
        ListCollectionView _items;
        public ListCollectionView Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public RelayCommand LoadCommand =>
            new RelayCommand(Load, CanLoad);

        public RelayCommand CalculateCommand =>
             new RelayCommand(Calculate, CanCalculate);

        public RelayCommand ResetCommand =>
             new RelayCommand((obj)=> Items = null);

        Library _lib;
        public MainWindowViewModel()
        {
            _lib = new Library();


        }


        private bool CanLoad(object obj)
        {
            return Items == null;
        }

        private bool CanCalculate(object obj)
        {
            return Items != null;
        }

        private void Load(object obj)
        {
            Items = new ListCollectionView(_lib.GetPeople());

            //Items.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Descending));
            //Items.Filter = new Predicate<object>(x => (x as Person).Age == 23 || (x as Person).Name == "하1");
            //Items.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
        }


        private void Calculate(object obj)
        {
            foreach (var item in Items)
            {
                if (item !=null && item is Person)
                {
                    var temp = item as Person;
                    _lib.Calculate(ref temp);
                }
            }
            Items.Refresh();
        }


    }
}
