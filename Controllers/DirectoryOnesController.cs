using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DirectoryOnesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly CustomServiceDirectoryOne customSDO = new CustomServiceDirectoryOne();

        public DirectoryOnesController(ApplicationDbContext context, IMapper mapper, CustomServiceDirectoryOne customSDO)
        {
            this.context = context;
            this.mapper = mapper;
            this.customSDO = customSDO;
        }

        // GET: api/DirectoryOnes
        [HttpGet]
        public async Task <IEnumerable<DirectoryOne>> GetDirectoryOnes()
        {
            return await customSDO.GetDirectoryOnes(context);
        }

        // GET: api/DirectoryOnes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectoryOne>> GetDirectoryOne(int id)
        {
            var directoryOne = await customSDO.GetDirectoryOneId(context, id);

            if (directoryOne == null)
            {
                return NotFound();
            }

            var directoryOneViewModel = mapper.Map<AutoMapperUser>(directoryOne);
            return directoryOne;
        }

        // PUT: api/DirectoryOnes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectoryOne(int id, DirectoryOne directoryOne)
        {
            if (id != directoryOne.Id)
            {
                return BadRequest();
            }

            await customSDO.PutDirectoryOne(context, directoryOne);
            return NoContent();
        }

        // POST: api/DirectoryOnes
        [HttpPost]
        public async Task<ActionResult<DirectoryOne>> PostDirectoryOne(DirectoryOne directoryOne)
        {
            await customSDO.PostDirectoryOne(context, directoryOne);
            return CreatedAtAction("GetDirectoryOne", new { id = directoryOne.Id }, directoryOne);
        }

        // DELETE: api/DirectoryOnes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DirectoryOne>> DeleteDirectoryOne(int id)
        {
            return await customSDO.DeleteDirectoryOne(context, id);            
        }

        private bool DirectoryOneExists(int id)
        {
            return context.DirectoryOnes.Any(e => e.Id == id);
        }
    }
}
