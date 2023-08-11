using BeerApplication.DataAccess.Entities;


namespace BeerApplication.Services
{
    public interface IBeerService
    {
        IEnumerable<Beer> GetAll();
        Beer GetById(Guid id);
        IEnumerable<Beer> SearchByName(string searchTerm);
        Beer Create(Beer beer);
        string UpdateRating(Guid id, double newRating);
    }
}
