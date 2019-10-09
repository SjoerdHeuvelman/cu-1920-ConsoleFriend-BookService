namespace BookService.Lib.DTO
{
    public class BookStatisticsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RatingsCount { get; set; }
        public double ScoreAverage { get; set; }
    }
}
