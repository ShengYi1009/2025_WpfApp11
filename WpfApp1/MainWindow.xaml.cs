using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();
        List<Teacher> teachers = new List<Teacher>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            //新增學生資料
            students.Add(new Student() { StudentId = "S001", StudentName = "小明" });
            students.Add(new Student() { StudentId = "S002", StudentName = "小花" });
            students.Add(new Student() { StudentId = "S003", StudentName = "小白" });
            StudentComboBox.ItemsSource = students;
        }
    }
}