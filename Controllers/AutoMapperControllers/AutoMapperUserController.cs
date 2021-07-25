using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.ViewModel;

namespace RestApi.Controllers
{
    [Route("api/")]
    public class AutoMapperUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoMapperUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAutoMapperUsers")]
        public async Task<ActionResult<IEnumerable<AutoMapperUser>>> GetAutoMapperUsers()
        {
            return await _context.AutoMapperUsers.ToListAsync();
        }

        [HttpPost("AutoMapperUsers")]
        public async Task<ActionResult<AutoMapperUser>> PostAutoMapperUser(AutoMapperUser autoMapperUser)
        {
            _context.AutoMapperUsers.Add(autoMapperUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutoMapperUsers", new { id = autoMapperUser.Id }, autoMapperUser);
        }
    }
}
