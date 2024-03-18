using FitAppAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context) { 

            _context = context;
        
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUsers(User user)
        {



            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUsers(User user)
        {
            var dbUser = await _context.Users.FindAsync(user.id);
            if (dbUser == null)
                return BadRequest("Profile not found.");



            dbUser.email = user.email;
            dbUser.nickname = user.nickname;
            dbUser.password = user.password;
            dbUser.profileId = user.profileId;

            

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUsers(int id)
        {
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
                return BadRequest("Profile not found.");


            _context.Users.Remove(dbUser);

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
