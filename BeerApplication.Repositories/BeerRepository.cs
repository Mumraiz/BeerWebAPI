using BeerApplication.DataAccess.Data;
using BeerApplication.DataAccess.Entities;


namespace BeerApplication.Repositories
{
    public class BeerRepository : IBeerRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public BeerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Beer> GetAll()
        {
            return _dbContext.Beers;
        }

        public Beer GetById(Guid id)
        {
            return _dbContext.Beers.Find(id);

        }

        public IEnumerable<Beer> SearchByName(string searchTerm)
        {
            return _dbContext.Beers.Where(b => b.Name.Contains(searchTerm, System.StringComparison.OrdinalIgnoreCase));
        }

        public Beer Create(Beer beer)
        {
            _dbContext.Beers.Add(beer);
            _dbContext.SaveChanges();
            return beer;
        }

        public string UpdateRating(Guid id, double newRating)
        {
            var beerToUpdate = _dbContext.Beers.Find(id);
            if (beerToUpdate != null)
            {
                if (beerToUpdate.Rating.HasValue && beerToUpdate.RatingCount.HasValue)
                {
                    int totalRatings = beerToUpdate.RatingCount.Value;
                    double currentTotal = beerToUpdate.Rating.Value * totalRatings;
                    double newTotal = currentTotal + newRating;
                    totalRatings++;
                    beerToUpdate.Rating = newTotal / totalRatings;
                    beerToUpdate.RatingCount = totalRatings;
                }
                else
                {
                    beerToUpdate.Rating = newRating;
                    beerToUpdate.RatingCount = 1;
                }

                _dbContext.SaveChanges();
                return "Rating Updated Successfully";
            }
            return "No Record exists";
        }
    }
}
