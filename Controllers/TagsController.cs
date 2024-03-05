using System;
using Microsoft.AspNetCore.Mvc;
using controller_api_v1.Context;
using controller_api_v1.Models.Entity;
using controller_api_v1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace controller_api_v1.Controllers
{
    [ApiController]
    [Route("tag")]
    public class TagsController : Controller
    {
        private readonly EntityContext _context;

        public TagsController(EntityContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (tag == null)
            {
                return NoContent();

            }
            else
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();
                return Ok(tag);
            }

        }
        [HttpGet]
        public async Task<ActionResult<List<Tag>>> GetAll()
        {
            try
            {
                var  activeTags  = await _context.Tags.Where(tag => (bool)tag.isActive).ToListAsync();
                return Ok(activeTags);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var tag = await _context.Tags.FindAsync(id);
                return (bool)!tag.isActive ? throw new Exception($"Etiqueta {tag.description} é inativo") : Ok(tag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tag tag)
        {
            try
            {
                var existTag = await _context.Tags.FindAsync(id);
                if (existTag == null)
                {
                    return NotFound();
                }
                existTag.description = tag.description;
                existTag.created_at = tag.created_at;

                await _context.SaveChangesAsync();
                return Ok(existTag);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existTag = await _context.Tags.FindAsync(id);
                if (existTag == null)
                {
                    return NotFound();
                }
                existTag.isActive = false;

                await _context.SaveChangesAsync();
                return Ok(existTag);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                var existTag = await _context.Tags.FindAsync(id);
                if (existTag == null)
                {
                    return NotFound();
                }
                existTag.isActive = true;

                await _context.SaveChangesAsync();
                return Ok(existTag);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}
