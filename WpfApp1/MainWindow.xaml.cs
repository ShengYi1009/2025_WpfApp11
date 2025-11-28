using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            //新增學生資料
            students.Add(new Student { StudentId = "S001", StudentName = "陳小明" });
            students.Add(new Student { StudentId = "S002", StudentName = "林小華" });
            students.Add(new Student { StudentId = "S003", StudentName = "張大同" });
            StudentComboBox.ItemsSource = students;
            StudentComboBox.SelectedIndex = 0;

            //新增教師資料
            Teacher teacher1 = new Teacher("陳定宏");
            teacher1.TeachingCourses.Add(new Course
            {
                CourseName = "視窗程式程式設計",
                Type = "選修",
                Point = 3,
                OpeningClass = "四技資工2A",
                Tutor = teacher1
            });
            teacher1.TeachingCourses.Add(new Course
            {
                CourseName = "資料結構",
                Type = "必修",
                Point = 3,
                OpeningClass = "四技資工二丙",
                Tutor = teacher1
            });
            teacher1.TeachingCourses.Add(new Course
            {
                CourseName = "程式設計概論",
                Type = "必修",
                Point = 3,
                OpeningClass = "四技資工一甲",
                Tutor = teacher1
            });
            teachers.Add(teacher1);

            Teacher teacher2 = new Teacher("林怡君");
            teacher2.TeachingCourses.Add(new Course
            {
                CourseName = "作業系統",
                Type = "必修",
                Point = 3,
                OpeningClass = "四技資工2A",
                Tutor = teacher2
            });
            teacher2.TeachingCourses.Add(new Course
            {
                CourseName = "資料庫系統",
                Type = "選修",
                Point = 3,
                OpeningClass = "四技資工2B",
                Tutor = teacher2
            });
            teacher2.TeachingCourses.Add(new Course
            {
                CourseName = "計算機概論",
                Type = "必修",
                Point = 3,
                OpeningClass = "四技資工一甲",
                Tutor = teacher2
            });

            teachers.Add(teacher2);

            Teacher teacher3 = new Teacher("王美玲");
            teacher3.TeachingCourses.Add(new Course
            {
                CourseName = "網際網路概論",
                Type = "選修",
                Point = 3,
                OpeningClass = "四技資工2B",
                Tutor = teacher3
            });
            teacher3.TeachingCourses.Add(new Course
            {
                CourseName = "多媒體概論",
                Type = "選修",
                Point = 3,
                OpeningClass = "四技資工2A",
                Tutor = teacher3
            });
            teacher3.TeachingCourses.Add(new Course
            {
                CourseName = "軟體工程",
                Type = "必修",
                Point = 3,
                OpeningClass = "四技資工二丙",
                Tutor = teacher3
            });
            teachers.Add(teacher3);

            TeacherTreeView.ItemsSource = teachers;
        }
    }
}