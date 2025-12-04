using Microsoft.Win32;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Media.Media3D;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();
        List<Record> records = new List<Record>();

        Student selectedStudent = null;
        Teacher selectedTeacher = null;
        Course selectedCourse = null;
        Record selectedRecord = null;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            //新增學生資料
            students.Add(new Student { StudentId = "4B3G456", StudentName = "K割" });
            students.Add(new Student { StudentId = "4B3G123", StudentName = "撈大" });
            students.Add(new Student { StudentId = "4B3G666", StudentName = "伲趣" });
            StudentComboBox.ItemsSource = students;
            StudentComboBox.SelectedIndex = 0;

            //新增教師資料
            Teacher teacher1 = new Teacher("陳定宏");
            teacher1.TeachingCourses.Add(new Course
            {
                CourseName = "視窗程式設計",
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

            Teacher teacher2 = new Teacher("林木木");
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
                CourseName = "視窗程式設計",
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

            Teacher teacher3 = new Teacher("美感玲");
            teacher3.TeachingCourses.Add(new Course
            {
                CourseName = "生態倫理學",
                Type = "選修",
                Point = 3,
                OpeningClass = "四技資工2B",
                Tutor = teacher3
            });
            teacher3.TeachingCourses.Add(new Course
            {
                CourseName = "生命倫理學",
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

            foreach (Teacher teacher in teachers)
            {
                foreach (Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }

            CourseListBox.ItemsSource = courses;
        }

        private void TeacherTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (TeacherTreeView.SelectedItem is Teacher)
            {
                selectedTeacher = TeacherTreeView.SelectedItem as Teacher;
                InfoLabel.Content = $"選取教師：{selectedTeacher.TeacherName}";
            }
            if (TeacherTreeView.SelectedItem is Course)
            {
                selectedCourse = TeacherTreeView.SelectedItem as Course;
                InfoLabel.Content = $"選取課程：{selectedCourse.CourseName}，授課教師：{selectedCourse.Tutor.TeacherName}";
            }
        }

        private void CourseListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCourse = CourseListBox.SelectedItem as Course;
            if (selectedCourse != null)
            {
                InfoLabel.Content = $"選取課程：{selectedCourse.CourseName}，授課教師：{selectedCourse.Tutor.TeacherName}";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("請先選取學生及課程！");
            }
            else
            {
                Record newRecord = new Record
                {
                    SelectedCourse = selectedCourse,
                    SelectedStudent = selectedStudent
                };

                foreach (Record r in records)
                {
                    if (r.Equals(newRecord))
                    {
                        MessageBox.Show("此學生已選取該課程，無法重複選課！");
                        return;
                    }
                }

                records.Add(newRecord);
                RecordListView.ItemsSource = records;
                RecordListView.Items.Refresh();
            }
        }

        private void StudentComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStudent = StudentComboBox.SelectedItem as Student;
            if (selectedStudent != null)
            {
                InfoLabel.Content = $"選取學生：{selectedStudent.StudentName}";
            }
        }

        private void RecordListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedRecord = RecordListView.SelectedItem as Record;
            if (selectedRecord != null)
            {
                InfoLabel.Content = $"選取記錄：學生 {selectedRecord.SelectedStudent.StudentName}，課程 {selectedRecord.SelectedCourse.CourseName}";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecord != null)
            {
                records.Remove(selectedRecord);
                RecordListView.ItemsSource = records;
                RecordListView.Items.Refresh();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Json File|*.json|All Files(*.*)|*.*",
                Title = "儲存選課記錄",
                DefaultExt = ".json",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                string jsonString = JsonSerializer.Serialize(records, options);
                File.WriteAllText(saveFileDialog.FileName, jsonString);
            }
        }
    }
}