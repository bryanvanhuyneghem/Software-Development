using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Student : Person
    {
        int studentNumber;

        public Student(string name, int studentNumber) : base(name)
        {
            this.studentNumber = studentNumber;
        }

        public int StudentNumber { get => studentNumber; set => studentNumber = value; }

        public override string WelcomeMessage => base.WelcomeMessage + ", your student number is " + studentNumber + ".";
    }
}
