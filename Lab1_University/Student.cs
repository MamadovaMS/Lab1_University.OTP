namespace Lab1_University
{
    public class Student : UniversityEntity
    {
        public string Group { get; set; }
        public string Direction { get; set; }

        public Student(string name, string contact, int experience, string group, string direction)
            : base(name, contact, experience)
        {
            Group = group;
            Direction = direction;
        }

        public override string GetInfo()
        {
            return $"🎓 СТУДЕНТ -> {base.GetInfo()}, Группа: {Group}, Направление: {Direction}";
        }
    }
}