using System.Text.Json.Serialization;

namespace Labb_4___API.Models
{
    [Serializable]
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int HobbyId { get; set; }
        [JsonIgnore]
        public Hobby? Hobby { get; set; }
        public int PersonId { get; set; }
        [JsonIgnore]
        public Person? Person { get; set; }
        

    }
}