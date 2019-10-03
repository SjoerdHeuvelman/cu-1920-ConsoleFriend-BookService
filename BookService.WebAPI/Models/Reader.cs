using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class Reader : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore] 
        public ICollection<Rating> Ratings { get; set; }

        public Reader()
        {
        }

        public Reader(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
