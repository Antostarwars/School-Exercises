namespace StudentOOP
{
    enum Subject
    {
        Italian,
        Maths,
        ComputerScience,
        English,
        History
    }

    class Student
    {
        private string name { get; }
        private string surname { get; }
        private int birthYear { get; }
        private Dictionary<Subject, List<int>> grades = new Dictionary<Subject, List<int>>();

        public Student(string name, string surname, int birthYear)
        {
            this.name = name;
            this.surname = surname;
            this.birthYear = birthYear;
        }

        public void addGrade(Subject subject, int grade)
        {
            if (grades.ContainsKey(subject))
            {
                grades[subject].Add(grade);
            }
            else
            {
                grades.Add(subject, new List<int> { grade });
            }
            return;
        }

        public double getAverage(Subject subject)
        {
            if (grades.ContainsKey(subject))
            {
                return grades[subject].Average();
            }
            else
            {
                return 0;
            }
        }

        public List<int> getGradesBy(Subject subject)
        {
            if (grades.ContainsKey(subject))
            {
                return grades[subject];
            }
            else
            {
                return new List<int>();
            }
        }
    }
}
