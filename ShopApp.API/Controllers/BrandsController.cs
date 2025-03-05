using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data.Context;
using ShopApp.API.DTOS.BrandDtos;
using ShopApp.Core.Entities;

namespace ShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public BrandsController(ShopDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(BrandCreateDto brandCreateDto)
        {
            if (_context.Brands.Any(x => x.Name == brandCreateDto.Name))
            {
                ModelState.AddModelError("Name", "Name is already Taken");
                return BadRequest(ModelState);
            }
            Brand brand = new Brand
            {
                Name = brandCreateDto.Name,

            };
            _context.Add(brandCreateDto);
            _context.SaveChanges();
            return StatusCode(201, brandCreateDto);
        }

        [HttpGet("{id}")]
        public ActionResult<BrandGetDto > Get (int id)// swaggerde tipi gosterir
        {
            Brand brand = _context.Brands.FirstOrDefault(b => b.Id == id);
            if (brand == null) return NotFound();

            BrandGetDto brandGetDto = new BrandGetDto
            {
                Name = brand.Name
            };
            return Ok(brandGetDto);
                
            
        }


        [HttpPut("{id}")] // bax
        public IActionResult Edit(int id,BrandEditDto brandEditDto)
        {
            Brand brand = _context.Brands.FirstOrDefault(b => b.Id == id);
            if (brand == null) return NotFound();

            if(_context.Brands.Any(x=> x.Name == brandEditDto.Name))
            {
                ModelState.AddModelError("Name", "Name is already Taken");
                return BadRequest(ModelState);
            }
            brand.Name = brandEditDto.Name;
            _context.SaveChanges(); 
            return NoContent();
        }


        [HttpGet("all")]
        public ActionResult<List<BrandAllItemDto>> GetAll()
        {
            var brands = _context.Brands.Select(x => new BrandAllItemDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(brands);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var values = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (values == null) return NotFound();

            _context.Brands.Remove(values);
            _context.SaveChanges();
            return NoContent();
        }









    }
}
