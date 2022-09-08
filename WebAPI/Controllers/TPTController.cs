using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPTController : ControllerBase
    {
        private readonly TPTDbContext _context;

        public TPTController(TPTDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var userlist = new List<User>
            {
                new(){Name = "Ömer Furkan",UserName="omerfurkandogruyol"},
                new(){Name = "Mehmet abi",UserName="mehmetabi"},
                new(){Name = "Ayşe Hanım",UserName="aysehanim"},
            };
            _context.Users.AddRange(userlist);
            var clientlist = new List<Client>
            {
                new() {Name = "Said",Email="said@hotmail.com"},
                new() {Name = "Elif",Email="elif@gmail.com"}
            };
            _context.Clients.AddRange(clientlist);
            return Ok(await _context.SaveChangesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = _context.People.ToList();
            var users = _context.Users.ToList();
            var clients = _context.Clients.ToList();
            var bb = await _context.People.OfType<Client>().ToListAsync();
            //Get only specified type into list
            var aa = people.OfType<Client>().ToList();
            return Ok(clients);
        }
    }
}
