using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class Rating : EntityBase
    {
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Score { get; set; }

        public Rating()
        {
        }

        public Rating(int id, int readerId, int bookId, int score)
        {
            Id = id;
            ReaderId = readerId;
            BookId = bookId;
            Score = score;
        }
    }
}
