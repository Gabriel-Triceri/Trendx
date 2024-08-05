using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lista_de_Tarefas.Models;
using Lista_de_Tarefas.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_de_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DbContextSqlServer _context;

        public TasksController(DbContextSqlServer context)
        {
            _context = context;
        }


        /// <summary>
        /// Obtém uma lista de todas as tarefas.
        /// </summary>
        /// <returns>Uma lista de tarefas.</returns>
        /// <response code="200">Retorna a lista de tarefas.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
            return await _context.Tarefas.ToListAsync();
        }

        /// <summary>
        /// Obtém uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">O ID da tarefa a ser recuperada.</param>
        /// <returns>Se a tarefa for encontrada, retorna a tarefa com o ID especificado. Caso contrário, retorna um status 404.</returns>
        /// <response code="200">Retorna a tarefa com o ID especificado.</response>
        /// <response code="404">Se a tarefa com o ID especificado não for encontrada.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTask(int id)
        {
            var task = await _context.Tarefas.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        /// <summary>
        /// Cria uma nova tarefa.
        /// </summary>
        /// <param name="task">O objeto da tarefa a ser criada.</param>
        /// <returns>Retorna a tarefa criada com um status 201 e o local do recurso.</returns>
        /// <response code="200">Retorna a tarefa criada e o local do recurso.</response>
        /// <response code="400">Se o objeto da tarefa estiver inválido.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTask(Tasks task)
        {
            _context.Tarefas.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.id }, task);
        }

        /// <summary>
        /// Atualiza uma tarefa existente com base no ID fornecido.
        /// </summary>
        /// <param name="id">O ID da tarefa a ser atualizada.</param>
        /// <param name="task">O objeto da tarefa contendo as novas informações para atualização.</param>
        /// <returns>Retorna um status 204 se a atualização for bem-sucedida. Se o ID não corresponder, retorna um status 400 . Se a tarefa não for encontrada, retorna um status 404 .</returns>
        /// <response code="204">Retorna um status 204  indicando que a atualização foi bem-sucedida.</response>
        /// <response code="400">Se o ID fornecido não corresponder ao ID da tarefa no corpo da solicitação.</response>
        /// <response code="404">Se a tarefa com o ID especificado não for encontrada.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Tasks task)
        {
            if (id != task.id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
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

        /// <summary>
        /// Remove uma tarefa existente pelo ID.
        /// </summary>
        /// <param name="id">O ID da tarefa a ser removida.</param>
        /// <returns>Retorna um status 204 (No Content) se a tarefa for removida com sucesso. Se a tarefa com o ID especificado não for encontrada, retorna um status 404 (Not Found).</returns>
        /// <response code="204">Retorna um status 204, indicando que a tarefa foi removida com sucesso.</response>
        /// <response code="404">Se a tarefa com o ID especificado não for encontrada.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tarefas.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TasksExists(int id)
        {
            return _context.Tarefas.Any(e => e.id == id);
        }
    }
}
