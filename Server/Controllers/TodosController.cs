using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TodoMvvmApp.Server.Features;
using TodoMvvmApp.Shared;

namespace TodoMvvmApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosService _todos;

        public TodosController(ITodosService todos)
        {
            _todos = todos;
        }

        // GET: api/Todos
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todos.GetAll();
        }

        // GET: api/Todos/5
        [HttpGet("{id:guid}", Name = "Get")]
        public Todo Get(Guid id)
        {
            return _todos.Get(id);
        }

        // POST: api/Todos
        [HttpPost]
        public void Post([FromBody] Todo todo)
        {
            _todos.Add(todo);
        }

        // PUT: api/Todos/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] Todo todo)
        {
            _todos.Update(todo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _todos.Remove(id);
        }
    }
}
