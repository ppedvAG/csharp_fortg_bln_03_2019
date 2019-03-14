namespace ReflectionTests
{
    public class Person
    {
        public string Name { get; set; }
        public int Alter { get; set; }
        [SortingDescription("Körpergröße")]
        public int Größe { get; set; }
        [NonSortable]
        public string ID { get; set; }


        public Person(string name, int alter, int höhe)
        {
            Name = name;
            Alter = alter;
            Größe = höhe;
        }

        public override string ToString()
        {
            return $"{Name}, ({Alter}), {Größe} cm groß!";
        }
    }
}
