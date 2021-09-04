using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientCall.Model;
using ClientCall.Service;

namespace ClientCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IService<Client> _context;

        public ClientsController(IService<Client> context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public  ActionResult<IEnumerable<Client>> GetClients()
        {
            var clients = _context.List();
            return clients;
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ActionResult<Client> GetClient(int id)
        {
            var client = _context.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, Client client)
        {
            if (id != client.Clint_Id)
            {
                return BadRequest();
            }

            _context.Edit(id, client);

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Client> PostClient(Client client)
        {
            _context.Create(client);

            return CreatedAtAction("GetClient", new { id = client.Clint_Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client =  _context.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Delete(id);

            return NoContent();
        }

    }
}
