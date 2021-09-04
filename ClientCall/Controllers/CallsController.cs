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
    public class CallsController : ControllerBase
    {
        private readonly IServiceCalls<Calls> _context;

        public CallsController(IServiceCalls<Calls> context)
        {
            _context = context;
        }

        // GET: api/Calls
        [HttpGet]
        public ActionResult<IEnumerable<Calls>> GetCalls()
        {
            return  _context.List();
        }

        // GET: api/Calls/5
        [HttpGet("{id}/{id_client}")]
        public ActionResult<Calls> GetCalls(int id,int id_client)
        {
            var calls =  _context.GetById(id,id_client);

            if (calls == null)
            {
                return NotFound();
            }

            return calls;
        }

        [HttpGet("GetCallsClients/{id}")]
        public ActionResult<IEnumerable<Calls>> GetCallsClients(int id)
        {
            var calls = _context.GetAllCallsById(id);

            if (calls == null)
            {
                return NotFound();
            }

            return calls;
        }



        // PUT: api/Calls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCalls(int id, Calls calls)
        {
            if (id != calls.Call_Id)
            {
                return BadRequest();
            }
            _context.Edit(id, calls.Client_Id, calls);
            return NoContent();
        }

        // POST: api/Calls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Calls> PostCalls(Calls calls)
        {
            _context.Create(calls);

            return CreatedAtAction("GetCalls", new { id = calls.Call_Id }, calls);
        }

        // DELETE: api/Calls/5
        [HttpDelete("{id}/{id_client}")]
        public IActionResult DeleteCalls(int id, int id_client)
        {
            var calls = _context.GetById(id,id_client);
            if (calls == null)
            {
                return NotFound();
            }

            _context.Delete(id, id_client);

            return NoContent();
        }

    }
}
