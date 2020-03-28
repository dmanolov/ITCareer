using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse: Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string name) : base(name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName) : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
                 :base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public override string DataToString()
        {
            string result = base.DataToString();
            if (this.Town != null)
            {
                result = result + "; Town = " + this.Town;
            }
            return result;
        }
    }
}
