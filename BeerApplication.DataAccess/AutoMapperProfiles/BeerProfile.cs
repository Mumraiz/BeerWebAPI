using AutoMapper;
using BeerApplication.DataAccess.Entities;


namespace BeerApplication.DataAccess.AutoMapperProfiles
{
    public class BeerProfile : Profile
    {
        public BeerProfile()
        {

            CreateMap<BeerCreateDTO, Beer>();
        }
    }
}
