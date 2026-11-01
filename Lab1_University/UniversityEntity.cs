namespace Lab1_University
{
    public abstract class UniversityEntity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public int Experience { get; set; }

        public UniversityEntity(string name, string contact, int experience)
        {
            Name = name;
            Contact = contact;
            Experience = experience;
        }

        public virtual string GetInfo()
        {
            return $"ФИО: {Name}, Контакты: {Contact}, Стаж: {Experience}";
        }
    }
}