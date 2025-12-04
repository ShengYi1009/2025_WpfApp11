using System.Collections.ObjectModel;

namespace WpfApp1
{
    internal class Teacher
    {
        public String TeacherName { get; set; }

        public ObservableCollection<Course> TeachingCourses { get; set; }

        public Teacher(String teacherName)
        {
            TeacherName = teacherName;
            TeachingCourses = new ObservableCollection<Course>();
        }

    }
}
