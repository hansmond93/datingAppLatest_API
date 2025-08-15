﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext dbContext) : ControllerBase()
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetMembers()
        {
            var members = await dbContext.Users.ToListAsync();

            return members;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member = await dbContext.Users.FindAsync(id);

            if (member == null) return NotFound();

            return member;
        }
    }
}
