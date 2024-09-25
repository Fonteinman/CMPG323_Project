using CCD_SHARE2TEACH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CCD_SHARE2TEACH.Controllers
{
    [Route("/ROLES")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RolesDbContext _rolesContext;

        public RolesController(RolesDbContext rolesContext)
        {
            _rolesContext = rolesContext;
        }

        // Get : api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ROLES>>> GetRoles()
        {
            if (_rolesContext.ROLES == null)
            {
                return NotFound();
            }
            return await _rolesContext.ROLES.ToListAsync();
        }

        // Get : api/Roles/2
        [HttpGet("{id}")]
        public async Task<ActionResult<ROLES>> GetRole(int id)
        {
            if (_rolesContext.ROLES is null)
            {
                return NotFound();
            }
            var role = await _rolesContext.ROLES.FindAsync(id);
            if (role is null)
            {
                return NotFound();
            }
            return role;
        }

        // Post : api/Roles
        [HttpPost]
        public async Task<ActionResult<ROLES>> PostStudent(ROLES role)
        {
            _rolesContext.ROLES.Add(role);
            await _rolesContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }

        // Put : api/Roles/2
        [HttpPut]
        public async Task<ActionResult<ROLES>> PutRoles(int id, ROLES role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            _rolesContext.Entry(role).State = EntityState.Modified;
            try
            {
                await _rolesContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id)) { return NotFound(); }
                else { throw; }
            }
            return NoContent();
        }

        private bool RoleExists(long id)
        {
            return (_rolesContext.ROLES?.Any(role => role.Id == id)).GetValueOrDefault();
        }

        // Delete : api/Roles/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<ROLES>> DeleteRole(int id)
        {
            if (_rolesContext.ROLES is null)
            {
                return NotFound();
            }
            var role= await _rolesContext.ROLES.FindAsync(id);
            if (role is null)
            {
                return NotFound();
            }
          _rolesContext.ROLES.Remove(role);
            await _rolesContext.SaveChangesAsync();
            return NoContent();
        }

    }
}