using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    internal class Student
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Double Percentage { get; set; }

        public Student(int id, String FirstName, String LastName, Double Percentage)
        {
            this.Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Percentage = Percentage;
        }

        public override string ToString()
        {
            //return base.ToString();
            return "id:" + Id + ", FirstName:" + FirstName + ", LastName:" + LastName + ", Percentage:" + Percentage;
        }

    }
}
