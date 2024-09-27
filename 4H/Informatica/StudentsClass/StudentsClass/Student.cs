namespace StudentsClass
{
    class Student
    {
        private readonly string surname;
        private readonly string name;
        private readonly char genre;
        private readonly DateOnly bornDate;
        private AcademicClass academicClass;

        public Student(string surname, string name, char genre, DateOnly bornDate, AcademicClass academicClass)
        {
            this.surname = surname;
            this.name = name;
            this.genre = genre;
            this.bornDate = bornDate;
            this.academicClass = academicClass;
        }

        public string Surname { get { return surname; } }
        public string Name { get { return name; } }
        public char Genre { get { return genre; } }
        public DateOnly BornDate { get { return bornDate; } }
        public AcademicClass AcademicClass { get { return academicClass; } }
    }
}
