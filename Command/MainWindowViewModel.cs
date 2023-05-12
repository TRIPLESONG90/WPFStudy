using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
