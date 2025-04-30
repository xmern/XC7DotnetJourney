using DotnetApi1.DbContexts;
using DotnetApi1.Models;
using DotnetApi1.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtsController:ControllerBase
    {
        private readonly ShirtDbContext _context;
        public ShirtsController(ShirtDbContext dbcon) {
            _context = dbcon;
        }
        [Route("get-all-shirts")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shirt>>> GetAllShirts()
        {
            var allShirts = await _context.Shirts.ToListAsync();
            return Ok(allShirts);
        }
        [Route("create-shirt")]
        [HttpPost]
        public async Task<IActionResult> CreateShirt([FromBody] Shirt shirtObj)
        {
            await _context.Shirts.AddAsync(shirtObj);
            _context.SaveChanges();
            return Ok();
        }
        [Route("modify-shirt")]
        [HttpPut]
        public async Task< IActionResult> UpdateShirt(Shirt shirtObj)
        {
            var shirt = await _context.Shirts.FindAsync(shirtObj.Id);
            if (shirt != null)
            {
                shirt.Texture = shirtObj.Texture;
                shirt.Colour = shirtObj.Colour;
                shirt.Material = shirtObj.Material;
                shirt.Type = shirtObj.Type;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
        [Route("modify-shirt-colour")]
        [HttpPut]
        public async Task<IActionResult> UpdateShirtColour([FromBody] ChangeShirtColourDto data)
        {
            var shirt = await  _context.Shirts.FindAsync(data.Id);
            if (shirt != null)
            {
                shirt.Colour = data.Colour;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            
            if (2 == 2)
            {
                return NotFound();
            }
            
        }
    }
}
