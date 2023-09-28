using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // to get to this controller
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        
        public ProductsController(StoreContext context)
        {
            _context = context;
            
            
        }

        //Defining end points: HttpGet and post if creating a resource, 
        //HttpPut if updating and HttpDel to delete the resource

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }


    }
}