using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeedStorm.Core.Entities;

namespace SeedStorm.Core.Controllers
{
    [Authorize(Roles = Role.Administrator)]
    [Route("api/clusters")]
    [ApiController]
    public class ClustersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ClustersController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cluster>>> GetClusters()
        {
            return await _context.Clusters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cluster>> GetCluster(Guid id)
        {
            var cluster = await _context.Clusters.FindAsync(id);

            if (cluster == null)
            {
                return NotFound();
            }

            return cluster;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCluster(Guid id, Cluster cluster)
        {
            if (id != cluster.Id)
            {
                return BadRequest();
            }

            _context.Entry(cluster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClusterExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Cluster>> PostCluster(Cluster cluster)
        {
            _context.Clusters.Add(cluster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCluster", new { id = cluster.Id }, cluster);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cluster>> DeleteCluster(Guid id)
        {
            var cluster = await _context.Clusters.FindAsync(id);
            if (cluster == null)
            {
                return NotFound();
            }

            _context.Clusters.Remove(cluster);
            await _context.SaveChangesAsync();

            return cluster;
        }

        private bool ClusterExists(Guid id)
        {
            return _context.Clusters.Any(e => e.Id == id);
        }
    }
}
