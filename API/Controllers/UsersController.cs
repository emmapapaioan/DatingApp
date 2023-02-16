using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext context;

        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        //async Task<..> was added to have asychronus function 
        //so a lot of requests can be done at the same time
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //when we add async to he method, we also have to put the keyword
            //await and at the methods are ending to Async also
            return await this.context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await this.context.Users.FindAsync(id);
        }
    }
}