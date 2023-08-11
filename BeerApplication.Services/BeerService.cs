using BeerApplication.DataAccess.Entities;
using BeerApplication.Repositories;


namespace BeerApplication.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepo;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepo = beerRepository;
        }


        public IEnumerable<Beer> GetAll()
        {
            return _beerRepo.GetAll().ToList();

        }
        public Beer GetById(Guid id)
        {
            //if (id < 0)
            //    throw new Exception("Employee Id cannot be less than zero");
            return _beerRepo.GetById(id);

        }
        public IEnumerable<Beer> SearchByName(string searchTerm)
        {
            return _beerRepo.SearchByName(searchTerm);
        }
        public Beer Create(Beer beer)
        {
            if (string.IsNullOrEmpty(beer.Type))
                throw new Exception("Beer type is empty!");
            if (string.IsNullOrEmpty(beer.Name))
                throw new Exception("Beer Name is empty!");
            return _beerRepo.Create(beer);

        }
        public string UpdateRating(Guid id, double newRating)
        {
            if (newRating == 0.0 || newRating < 0)
                throw new Exception("Invalid Rating provided");
            return _beerRepo.UpdateRating(id, newRating);
        }
    }
}
