using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_GUI
{
    public abstract class Person
    {
        private string _firstName, _midInit, _lastName;
        private int _age;
        private readonly string _id;

        public Person()
        {

        }

        public Person(string id, string firstName, string midInit, string lastName, int age)
        {
            _id = id;
            FirstName = firstName;
            MidInit = midInit;
            LastName = lastName;
            Age = age;
        }

        public string ID { get { return _id; } }

        public string FirstName { get { return _firstName; } set { _firstName = value; } }

        public string MidInit { get { return _midInit; } set { _midInit = value; } }

        public string LastName { get { return _lastName; } set { _lastName = value; } }

        public int Age
        {
            get { return _age; }
            set
            {
                if(value < 0)
                {
                    _age = 0;
                    throw (new AgeBelowZeroException());
                }
                else
                {
                    _age = value;
                }
            }
        }

        public abstract string DisplayInformation();

    }
}
