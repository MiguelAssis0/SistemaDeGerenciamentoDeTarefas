using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaGerenciadorDeTarefas.Context;

namespace SistemaGerenciadorDeTarefas.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TaskContext _context;

        public TarefaController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Tarefa = _context.Tarefas.Find(id);
            if (Tarefa == null)
                return NotFound();
            return Ok(Tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Tarefa tarefa, int id)
        {
            tarefa.Id = id;
            if (tarefa.Id != id)
                return BadRequest();
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_context.Tarefas.ToList());
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string nome)
        {
            var tarefa = _context.Tarefas.Where(n => n.Nome.Contains(nome));

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }


        [HttpGet("GetByData")]
        public IActionResult GetByData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(n => n.Data == data);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpGet("GetByStatus")]
        public IActionResult GetByStatus(StatusTarefa status)
        {
            var tarefa = _context.Tarefas.Where(n => n.Status == status);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpPost("Create")]
        public IActionResult Create(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);

        }
    }
}