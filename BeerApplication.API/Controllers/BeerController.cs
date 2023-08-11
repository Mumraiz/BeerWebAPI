using AutoMapper;
using BeerApplication.DataAccess.Entities;
using BeerApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeerApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBeerService _beerService;

        public BeerController(IMapper mapper, IBeerService beerService)
        {
            _mapper = mapper;
            _beerService = beerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var beers = _beerService.GetAll();
            if (!beers.Any())
            {
                return NotFound("No Record Exists");
            }
            return Ok(beers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var beer = _beerService.GetById(id);
            if (beer == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(beer);
        }

        [HttpGet("search")]
        public IActionResult SearchByName(string term)
        {
            var beers = _beerService.SearchByName(term);
            if (beers == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(beers);
        }

        [HttpPost]
        public IActionResult Create(BeerCreateDTO beerDTO)
        {
            if (beerDTO == null)
            {
                return BadRequest("Invalid data");
            }
            var beer = _mapper.Map<Beer>(beerDTO);
            if (beer.Rating.HasValue && beer.RatingCount == null)
            {
                beer.RatingCount = 1;
            }
            beer.Id = Guid.NewGuid();
            var createdBeer = _beerService.Create(beer);
            return CreatedAtAction(nameof(GetById), new { id = createdBeer.Id }, createdBeer);
        }

        [HttpPatch("{id}/updateRating")]
        public IActionResult UpdateRating(Guid id, [FromBody] double newRating)
        {
            string message = _beerService.UpdateRating(id, newRating);
            if (message == "Rating Updated Successfully")
            {
                return Ok(message);
            }
            else
            {
                return NotFound(message);
            }
        }
    }
}
