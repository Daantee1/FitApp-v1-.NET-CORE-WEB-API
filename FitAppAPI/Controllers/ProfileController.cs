using FitAppAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FitAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfileController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            return Ok(await _context.Profiles.ToListAsync());
        }
        [HttpPost]

        public async Task<ActionResult<List<Profile>>> CreateProfiles(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return Ok(await _context.Profiles.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Profile>>> UpdateProfiles(Profile profile)
        {
            var dbProfile = await _context.Profiles.FindAsync(profile.id);
            if(dbProfile == null)
                return BadRequest("Profile not found.");


                dbProfile.gender = profile.gender;
                dbProfile.age = profile.age;
                dbProfile.weight = profile.weight;
                dbProfile.height = profile.height;
                dbProfile.activity = profile.activity;
                dbProfile.goal = profile.goal;
                dbProfile.userId = profile.userId;

                await _context.SaveChangesAsync();
                return Ok(await _context.Profiles.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Profile>>> DeleteProfiles(int id)
        {
            var dbProfile = await _context.Profiles.FindAsync(id);
            if (dbProfile == null)
                return BadRequest("Profile not found.");


            _context.Profiles.Remove(dbProfile);

            await _context.SaveChangesAsync();
            return Ok(await _context.Profiles.ToListAsync());
        }
    }
}
