namespace Labb_4___API.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Person> Persons { get; set; }

        public ICollection<Link> Links { get; set; }

    }
}