using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;
using UnitOFWorkPattern.Interface;
using UnitOFWorkPattern.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnitOFWorkPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _repository;
        private readonly SieveProcessor _sieveProcessor;

        public ToDoController(IToDoService repository, SieveProcessor sieveProcessor)
        {
            this._repository = repository;
            this._sieveProcessor = sieveProcessor;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public List<ToDo> Get([FromQuery] SieveModel model)
        {
            var task = _repository.GetAllTask().AsQueryable();
            task = _sieveProcessor.Apply(model, task);
            return task.ToList();
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public ToDo Get(int id)
        {
            var result = _repository.ToDoGetTaskById(id);
            return result;
        }

        // POST api/<ToDoController>
        [HttpPost]
        public ToDo Post([FromBody] ToDo value)
        {
            var task = _repository.AddTask(value);
            return task;
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public ToDo Put(int id, [FromBody] ToDo value)
        {
            if(id != value.Id)
            {
                throw new Exception("Please Enter Valid ID");
            }
            var result = _repository.UpdateTask(value);
            return result;
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool result = _repository.DeleteTaskByID(id);
            return result;
        }
    }
}
