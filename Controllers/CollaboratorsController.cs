using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using controller_api_v1.Context;
using controller_api_v1.Models.Entity;

namespace controller_api_v1.Controllers
{
    [ApiController]
    [Route("collaborator")]
    public class CollaboratorsController : ControllerBase
    {
        private readonly EntityContext _context;

        public CollaboratorsController(EntityContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Collaborator collaborator)
        {
            if (collaborator == null)
            {
               return NoContent();

            }else
            {
                _context.Add(collaborator);
                await _context.SaveChangesAsync();
                return Ok(collaborator);
            }
               
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var collaborators =  await _context.Collaborators.Where(collaborator => (bool)collaborator.isActive).ToListAsync();
                return Ok(collaborators);
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
                var collaborator = await _context.Collaborators.FindAsync(id);
                return (bool)!collaborator.isActive ? throw new Exception($"Colaborador {collaborator.nickName} é inativo" ) : Ok(collaborator);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Collaborator collaborator)
        {
            try
            {
                var existCollaborator = await _context.Collaborators.FindAsync(id);
                if (existCollaborator == null)
                {
                    return NotFound();
                }
                existCollaborator.nickName = collaborator.nickName;
                existCollaborator.nickName = collaborator.nickName;

                await _context.SaveChangesAsync();
                return Ok(existCollaborator);

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
                var existCollaborator = await _context.Collaborators.FindAsync(id);
                if (existCollaborator == null)
                {
                    return NotFound();
                }
                existCollaborator.isActive = false;

                await _context.SaveChangesAsync();
                return Ok(existCollaborator);

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
                var existCollaborator = await _context.Collaborators.FindAsync(id);
                if (existCollaborator == null)
                {
                    return NotFound();
                }
                existCollaborator.isActive = true;

                await _context.SaveChangesAsync();
                return Ok(existCollaborator);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
