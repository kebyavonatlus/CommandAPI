using System.Collections.Generic;
using CommandAPI.Data;
using CommandAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        [HttpGet("{Id}")]
        public ActionResult<Command> GetCommandId(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if  (commandItem == null) return NotFound();

            return Ok(commandItem);
        }
    }
}