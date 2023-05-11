using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class BindingObject
    {
        public string Temp { get; set; }
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
    }
}
