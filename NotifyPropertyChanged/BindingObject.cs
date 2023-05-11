using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyPropertyChanged
{
    public class BindingObject : INotifyPropertyChanged
    {
        string _temp;
        public string Temp
        {
            get => _temp;
            set
            {
                _temp = value;
                OnPropertyChanged(nameof(Temp));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temp)));
            }
        }

        public BindingObject()
        {
            Temp = "Text";
        }
        public BindingObject(string text)
        {
            if (String.IsNullOrEmpty(text))
                Temp = "Text";
            else
                Temp = text;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
