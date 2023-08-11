

namespace BeerApplication.DataAccess.Entities
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double? Rating { get; set; }
        public int? RatingCount { get; set; }
    }
}
