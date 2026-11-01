namespace Lab1_University
{
    public class Teacher : UniversityEntity
    {
        public string Degree { get; set; }
        public string Courses { get; set; }

        public Teacher(string name, string contact, int experience, string degree, string courses)
            : base(name, contact, experience)
        {
            Degree = degree;
            Courses = courses;
        }

        public override string GetInfo()
        {
            return $"👨‍🏫 ПРЕПОДАВАТЕЛЬ -> {base.GetInfo()}, Степень: {Degree}, Курсы: {Courses}";
        }
    }
}