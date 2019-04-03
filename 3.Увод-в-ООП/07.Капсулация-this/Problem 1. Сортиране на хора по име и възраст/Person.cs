using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Сортиране_на_хора_по_име_и_възраст
{
    class Person
    {
        /* Създайте class Person, който да има private полета:
•	firstName: string
•	lastName: string
•	age: int
•	ToString(): string - override
*/
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get => firstName;
        }
        public string Name
        {
            get => firstName + " " + lastName;
        } 
        public int Age
        {
            get => age;
        }
        public override string ToString()
        {
            return Name + " is a " + Age + " years old";
        }
        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
    }
}
