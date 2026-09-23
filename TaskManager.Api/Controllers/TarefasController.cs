using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.DTOs;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/v1/tarefas")]
public class TarefasController : ControllerBase
{
    private readonly AppDbContext _context;

    public TarefasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefa>>> BuscarTodas()
    {
        var tarefas = await _context.Tarefas
            .AsNoTracking()
            .ToListAsync();

        return Ok(tarefas);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tarefa>> BuscarPorId(int id)
    {
        var tarefa = await _context.Tarefas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (tarefa is null)
            return NotFound();

        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<Tarefa>> Criar(CriarTarefaDto dto)
    {
        var tarefa = new Tarefa
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            Concluida = false,
            DataCriacao = DateTime.Now
        };

        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = tarefa.Id },
            tarefa);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Tarefa>> Atualizar(
        int id,
        AtualizarTarefaDto dto)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa is null)
            return NotFound();

        tarefa.Titulo = dto.Titulo;
        tarefa.Descricao = dto.Descricao;
        tarefa.Concluida = dto.Concluida;

        await _context.SaveChangesAsync();

        return Ok(tarefa);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa is null)
            return NotFound();

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}