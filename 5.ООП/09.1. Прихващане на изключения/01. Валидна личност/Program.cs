using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Валидна_личност
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName",
                        "The first name cannot be null or empty!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName",
                        "The last name cannot be null or empty!");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.Age;
            }

            set
            {
                if (value < 0|| 120 < value)
                {
                    throw new ArgumentOutOfRangeException("Age",
                        "The age cannot be null or more than 120 or negative!");
                }
                this.age = value;
            }

        }

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = Validate("Pesho", "Goshov", 23);
            Person p1 = Validate("", "Goshov", 23);
            Person p2 = Validate("Pesho", null, 23);
            Person p3 = Validate("Pesho", "Goshov", -1);
            Person p4 = Validate("Pesho", "Goshov", 200);
        }

        static Person Validate(string firstName, string lastName, int age)
        {
            try
            {
                return new Person(firstName, lastName, age);
            }
            catch (ArgumentNullException e)
            {
                if(e.ParamName == "FirstName") // специфична обработка
                {
                    Console.WriteLine("Humans must have FIRST NAME!");
                }
                Console.WriteLine($"Exception : {e.Message}");
                return null;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception : {e.Message}");
                return null;
            }
        }
    }

}
