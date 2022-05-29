using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIInventory.Controllers
{
    public class BaseItemController : ControllerBase
    {
        private readonly DataContext _context;

        public BaseItemController(DataContext context)
        {
            _context = context;
        }
    }
}
