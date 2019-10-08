using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.DTO
{
    public class BookStatisticsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RatingsCount { get; set; }
        public double ScoreAverage { get; set; }
    }
}
