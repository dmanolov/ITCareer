using System;

namespace Methods
{
    class Student
    {
        private string otherInfo;
        private DateTime birthDate;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string OtherInfo {
            get => otherInfo;
            set
            {
                birthDate = DateTime.Parse(value.Substring(value.Length - 10));
                otherInfo = value.Substring(0, value.Length - 20);
            }
        }
        public DateTime BirthDate { get => birthDate; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public bool IsOlderThan(Student other)
        {
            return this.BirthDate > other.BirthDate;
        }
    }
}
