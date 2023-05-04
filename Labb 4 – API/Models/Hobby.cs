using System.Text.Json.Serialization;

namespace Labb_4___API.Models
{
    [Serializable]
    public class Hobby //Interests
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }

        public ICollection<Link>? Links { get; set; }

    }
}