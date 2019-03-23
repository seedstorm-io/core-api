using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeedStorm.CoreApi;
using SeedStorm.CoreApi.Entities.NodeCatalog;

namespace core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeTemplatesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public NodeTemplatesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/NodeTemplates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeTemplate>>> GetNodesCatalog()
        {
            return await _context.NodesCatalog.ToListAsync();
        }

        // GET: api/NodeTemplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeTemplate>> GetNodeTemplate(Guid id)
        {
            var nodeTemplate = await _context.NodesCatalog.FindAsync(id);

            if (nodeTemplate == null)
            {
                return NotFound();
            }

            return nodeTemplate;
        }

        // PUT: api/NodeTemplates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNodeTemplate(Guid id, NodeTemplate nodeTemplate)
        {
            if (id != nodeTemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(nodeTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeTemplateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NodeTemplates
        [HttpPost]
        public async Task<ActionResult<NodeTemplate>> PostNodeTemplate(NodeTemplate nodeTemplate)
        {
            _context.NodesCatalog.Add(nodeTemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNodeTemplate", new { id = nodeTemplate.Id }, nodeTemplate);
        }

        // DELETE: api/NodeTemplates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NodeTemplate>> DeleteNodeTemplate(Guid id)
        {
            var nodeTemplate = await _context.NodesCatalog.FindAsync(id);
            if (nodeTemplate == null)
            {
                return NotFound();
            }

            _context.NodesCatalog.Remove(nodeTemplate);
            await _context.SaveChangesAsync();

            return nodeTemplate;
        }

        private bool NodeTemplateExists(Guid id)
        {
            return _context.NodesCatalog.Any(e => e.Id == id);
        }
    }
}
