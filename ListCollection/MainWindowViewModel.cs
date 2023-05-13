using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ListCollection
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        ListCollectionView _listBoxItems;
        public ListCollectionView ListBoxItems
        {
            get { return _listBoxItems; }
            set
            {
                _listBoxItems = value;
                OnPropertyChanged(nameof(ListBoxItems));
            }
        }

        ListCollectionView _listViewItems;
        public ListCollectionView ListViewItems
        {
            get { return _listViewItems; }
            set
            {
                _listViewItems = value;
                OnPropertyChanged(nameof(ListViewItems));
            }
        }

        ListCollectionView _dataGridItems;
        public ListCollectionView DataGridItems
        {
            get { return _dataGridItems; }
            set
            {
                _dataGridItems = value;
                OnPropertyChanged(nameof(DataGridItems));
            }
        }
        public MainWindowViewModel()
        {
            ListBoxItems = new ListCollectionView(new List<Person>()
            {
                new Person()
                {
                    Name = "홍길동",
                    Age = 33
                },
                new Person()
                {
                    Name = "홍두깨",
                    Age = 32
                },
                new Person()
                {
                    Name = "홍진경",
                    Age = 13
                },
            });

            ListViewItems = new ListCollectionView(new List<Person>()
            {
                new Person()
                {
                    Name = "홍길동",
                    Age = 33
                },
                new Person()
                {
                    Name = "홍두깨",
                    Age = 32
                },
                new Person()
                {
                    Name = "홍진경",
                    Age = 13
                },
            });

            DataGridItems = new ListCollectionView(new List<Person>()
            {
                new Person()
                {
                    Name = "홍길동",
                    Age = 33
                },
                new Person()
                {
                    Name = "홍두깨",
                    Age = 32
                },
                new Person()
                {
                    Name = "홍진경",
                    Age = 13
                },
            });
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
