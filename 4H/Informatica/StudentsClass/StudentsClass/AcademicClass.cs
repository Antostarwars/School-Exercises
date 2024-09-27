namespace StudentsClass
{
    class AcademicClass
    {
        private int year;
        private string section;
        private Course course;
        private List<Student> students;

        public AcademicClass(int year, string section, Course course)
        {
            this.year = year;
            this.section = section;
            this.course = course;
            this.students = new List<Student>();
        }

        public int Year { get { return year; } }
        public string Section { get { return section; } }
        public Course Course { get { return course; } }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public override string ToString()
        {
            return $"{year}{section}";
        }
    }
}
