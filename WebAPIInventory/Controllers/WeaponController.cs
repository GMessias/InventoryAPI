using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : BaseItemController
    {
        private readonly DataContext _context;

        public WeaponController(DataContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Weapon>>> Get()
        {
            return Ok(await _context.Weapons.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon>> Get(int id)
        {
            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon == null)
            {
                return BadRequest("Weapon not found.");
            }
            return Ok(weapon);
        }

        [HttpPost]
        public async Task<ActionResult<List<Weapon>>> AddWeapon(Weapon weapon)
        {
            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();

            return Ok(await _context.Weapons.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Weapon>>> UpdateWeapon(Weapon request)
        {
            var dbWeapon = await _context.Weapons.FindAsync(request.Id);
            if (dbWeapon == null)
            {
                return BadRequest("Weapon not found.");
            }

            dbWeapon.Name = request.Name;
            dbWeapon.Image = request.Image;
            dbWeapon.Description = request.Description;
            dbWeapon.Usable = request.Usable;
            dbWeapon.Type = request.Type;
            dbWeapon.Enchanted = request.Enchanted;
            dbWeapon.Stats.Attack = request.Stats.Attack;
            dbWeapon.Stats.MagicAttack = request.Stats.MagicAttack;
            dbWeapon.Stats.Defense = request.Stats.Defense;
            dbWeapon.Stats.MagicDefense = request.Stats.MagicDefense;
            dbWeapon.Stats.Evade = request.Stats.Evade;
            dbWeapon.Stats.Block = request.Stats.Block;
            dbWeapon.Stats.Resistance = request.Stats.Resistance;
            dbWeapon.TypeWeapon = request.TypeWeapon;
            dbWeapon.TypeAttack = request.TypeAttack;
            dbWeapon.Ammunition = request.Ammunition;

            await _context.SaveChangesAsync();

            return Ok(await _context.Weapons.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Weapon>>> Delete(int id)
        {
            var dbWeapon = await _context.Weapons.FindAsync(id);
            if (dbWeapon == null)
            {
                return BadRequest("Weapon not found.");
            }

            _context.Weapons.Remove(dbWeapon);
            await _context.SaveChangesAsync();

            return Ok(await _context.Weapons.ToListAsync());
        }
    }
}
