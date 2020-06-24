namespace DraftWpfApp
{
    public class Person
    {
        public Person(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public string Name { get; set; }
        public int ID { get; set; }
    }
}