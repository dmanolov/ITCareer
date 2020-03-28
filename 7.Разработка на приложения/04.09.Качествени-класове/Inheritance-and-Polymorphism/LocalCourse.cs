using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string name) : base(name)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName): base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students): base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public override string DataToString()
        {
            string result = base.DataToString();
            if (this.Lab != null)
            {
                result = result + "; Lab = " + this.Lab;
            }
            return result;
        }
    }
}
