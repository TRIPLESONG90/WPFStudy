using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Library
    {
        public Library()
        {

        }

        public List<Person> GetPeople()
        {
            var res = new List<Person>();
            for(int i=0; i < 100; i++)
            {
                res.Add(
                    new Person()
                    {
                        Name = $"하{i}",
                        Age = i
                    }
                );
            }
            return res;
        }
        
        public void Calculate(ref Person person)
        {
            person.Age += 1;
        }
    }
}
