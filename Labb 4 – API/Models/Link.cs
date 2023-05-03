namespace Labb_4___API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        

    }
}