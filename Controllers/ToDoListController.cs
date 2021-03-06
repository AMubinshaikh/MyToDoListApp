using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTodoApp_ISG.Model;
using MyTodoApp_ISG.Service;
using MyTodoApp_ISG.ViewModel;
namespace MyTodoApp_ISG.Controllers {

    [Route ("api/[controller]")]
    public class ToDoListController : Controller {
        private readonly TodoService _todoService;
        private readonly IMapper _mapper;

        
        public ToDoListController (TodoService todoService, IMapper mapper) {
            this._todoService = todoService;
            this._mapper = mapper;
        }

        [HttpGet ("[action]")]
        public async Task<IEnumerable<Todo>> GetTodos () {
            // Note: If you don't need to return to the calling thread, use .ConfigureAwait(false)
            return await _todoService.GetAll ().ConfigureAwait (false);
        }

        [HttpPost ("[action]")]
        public async Task<IActionResult> AddTodo (TodoAddViewModel todo) //[FromBody] 
        {
            if (todo != null) {
                // NOTE: Used AutoMapper for Object-to-Object mapping instead of old school viewModel 
                var mappedViewModel = new Todo {
                WorkTodo = todo.WorkTodo,
                IsCompleted = todo.IsCompleted
                };
                //var mappedViewModel = _mapper.Map<Todo>(todo); 
                int result = await _todoService.Add (mappedViewModel).ConfigureAwait (false);
                return Ok (result);
            }

            return BadRequest ();
        }

        [HttpDelete ("[action]/{Id}")]
        public async Task<IActionResult> DeleteTodo (int Id) {
            if (Id != 0) {
                return Ok (await _todoService.Delete (Id).ConfigureAwait (false));
            }
            return BadRequest ();
        }

        [HttpPut ("[action]/{Id}")]
        public async Task<IActionResult> UpdateTodo (int Id, [FromBody] TodoUpdateViewModel todo) {
            if (Id != 0 && todo != null) {

                var mappedViewModel = _mapper.Map<Todo> (todo);

                return Ok (await _todoService.Update (Id, mappedViewModel).ConfigureAwait (false));
            }
            return BadRequest ();
        }

        [HttpPut ("[action]/{Id}/{Completed}")]
        public async Task<IActionResult> MarkCompleted (int Id, bool Completed) {
            if (Id != 0) {
                return Ok (await _todoService.MarkCompleted (Id, Completed).ConfigureAwait (false));
            }
            return BadRequest ();
        }
   }
}