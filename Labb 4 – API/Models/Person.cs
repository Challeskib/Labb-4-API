﻿using System.Text.Json.Serialization;

namespace Labb_4___API.Models
    
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ICollection<Hobby> Hobbys { get; set; }


    }
}
