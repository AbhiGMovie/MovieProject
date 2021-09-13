using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies;
using Movies.Data;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MoviesContext _context;
        public UserController(MoviesContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        
        [HttpPost("[action]"),ActionName("login")]        
        public async Task<ActionResult<Users>> Login(Users users)
        {
            
            try
            {
                var user = await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.userName == users.userName && x.password == users.password);
                if (user == null)
                    return NotFound();
                else
                    return user;
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }
        [HttpPost("[action]"),ActionName("signup")]        
        public async Task<ActionResult<Users>> SignUp(Users user)
        {
            if (!UserExists(user.userName))
            {
                try
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("SignUp", new { id = user.Id }, user);
                }
                catch(Exception ex)
                {
                    return CreatedAtAction("SignUp", false);
                }
            }
            else
            {
                return CreatedAtAction("SignUp",false);
            }
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.userName == username);
        }
    }
}
