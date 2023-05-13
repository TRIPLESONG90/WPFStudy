using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace SampleProgram1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        ListCollectionView _users;
        public ListCollectionView Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        public RelayCommand AddCommand => new RelayCommand((obj) =>
        {
            Users.AddNewItem(
                new User()
                {
                    FirstName = $"석송",
                    LastName = "김",
                    AddedDate= DateTime.Now,
                });
            Users.CommitNew();
        });
        public RelayCommand EditCommand => new RelayCommand((obj) =>
        {
            Users.EditItem((Users.CurrentItem as User));
            (Users.CurrentItem as User).ModifiedDate = DateTime.Now;
            Users.CommitEdit();
            Users.Refresh();
        });

        public RelayCommand RemoveCommand => new RelayCommand((obj) =>
        {
            Users.Remove(Users.CurrentItem);
        });

        public MainWindowViewModel()
        {
            Users = new ListCollectionView(new List<User>());
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
