using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Методи
{
    class Family
    {
        private List<Person> family = new List<Person>();
        
        public void AddMember(Person member)
        {
            family.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = 0;
            Person oldestPerson = null;
            foreach (var p in family)
            {
                if (p.Age > maxAge)
                {
                    maxAge = p.Age;
                    oldestPerson = p;
                }
            }
            return oldestPerson;
        }


    }
}
