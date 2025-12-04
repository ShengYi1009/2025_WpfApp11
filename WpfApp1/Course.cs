using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Course
    {
        public String CourseName { get; set; }
        public String Type { get; set; }
        public int Point { get; set; }
        public String OpeningClass { get; set; }
        public Teacher Tutor { get; set; }
    }
}
