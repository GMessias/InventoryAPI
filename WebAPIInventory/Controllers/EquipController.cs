using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipController : BaseItemController
    {
        private readonly DataContext _context;

        public EquipController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equip>>> Get()
        {
            return Ok(await _context.Equips.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equip>> Get(int id)
        {
            var equip = await _context.Equips.FindAsync(id);
            if (equip == null)
            {
                return BadRequest("Equip not found.");
            }
            return Ok(equip);
        }

        [HttpPost]
        public async Task<ActionResult<List<Equip>>> AddEquip(Equip equip)
        {
            _context.Equips.Add(equip);
            await _context.SaveChangesAsync();

            return Ok(await _context.Equips.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Equip>>> UpdateEquip(Equip request)
        {
            var dbEquip = await _context.Equips.FindAsync(request.Id);
            if (dbEquip == null)
            {
                return BadRequest("Equip not found.");
            }

            dbEquip.Name = request.Name;
            dbEquip.Image = request.Image;
            dbEquip.Description = request.Description;
            dbEquip.Usable = request.Usable;
            dbEquip.Type = request.Type;
            dbEquip.Enchanted = request.Enchanted;
            dbEquip.Stats.Attack = request.Stats.Attack;
            dbEquip.Stats.MagicAttack = request.Stats.MagicAttack;
            dbEquip.Stats.Defense = request.Stats.Defense;
            dbEquip.Stats.MagicDefense = request.Stats.MagicDefense;
            dbEquip.Stats.Evade = request.Stats.Evade;
            dbEquip.Stats.Block = request.Stats.Block;
            dbEquip.Stats.Resistance = request.Stats.Resistance;

            await _context.SaveChangesAsync();

            return Ok(await _context.Equips.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Equip>>> Delete(int id)
        {
            var dbEquip = await _context.Equips.FindAsync(id);
            if (dbEquip == null)
            {
                return BadRequest("Equip not found.");
            }

            _context.Equips.Remove(dbEquip);
            await _context.SaveChangesAsync();

            return Ok(await _context.Equips.ToListAsync());
        }
    }
}
