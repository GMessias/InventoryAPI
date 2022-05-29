using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseItemController
    {    
        private readonly DataContext _context;

        public ItemController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {
            return Ok(await _context.Items.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if(item == null)
            {
                return BadRequest("Item not found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Item>>> AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Item>>> UpdateItem(Item request)
        {
            var dbItem = await _context.Items.FindAsync(request.Id);
            if (dbItem == null)
            {
                return BadRequest("Item not found.");
            }

            dbItem.Name = request.Name;
            dbItem.Image = request.Image;
            dbItem.Description = request.Description;
            dbItem.Usable = request.Usable;

            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> Delete(int id)
        {
            var dbItem = await _context.Items.FindAsync(id);
            if (dbItem == null)
            {
                return BadRequest("Item not found.");
            }

            _context.Items.Remove(dbItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        }
    }
}
