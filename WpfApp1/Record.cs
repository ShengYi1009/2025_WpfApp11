using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Record
    {
        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }

        public bool Equals(Record r)
        {
            return SelectedStudent.StudentId == r.SelectedStudent.StudentId &&
                   SelectedCourse.CourseName == r.SelectedCourse.CourseName;
        }
    }
}
