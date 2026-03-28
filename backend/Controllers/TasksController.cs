using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudBackend.Data;
using CloudBackend.Models;
using CloudBackend.DTOs;


namespace CloudBackend.Controllers;

[ApiController]
[Route("api/[controller]")] // Adres: http://localhost:8081/api/tasks
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    // Wstrzykiwanie zależności (Dependency Injection) kontekstu bazy danych
    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
	public async Task<ActionResult> GetAll()
	{
    var tasks = await _context.Tasks.ToListAsync();
    var dtos = tasks.Select(t => new TaskReadDto
    {
        Id = t.Id,
        Name = t.Name,
        IsCompleted = t.IsCompleted
    });
        return Ok(dtos);
	}


    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
    var task = await _context.Tasks.FindAsync(id);
    if (task == null) return NotFound();
    var dto = new TaskReadDto
    {
        Id = task.Id,
        Name = task.Name,
        IsCompleted = task.IsCompleted
    };
        return Ok(dto);
    }


    [HttpPost] // 3. Dodaj (CREATE)
    public async Task<ActionResult> Create(CloudTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        // Zwraca status 201 Created oraz lokalizację nowego zasobu
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")] // 4. Edytuj (UPDATE)
    public async Task<ActionResult> Update(int id, CloudTask task)
    {
        if (id != task.Id) return BadRequest("ID mismatch");
        if (!await _context.Tasks.AnyAsync(t => t.Id == id)) return NotFound();
        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent(); // Status 204 - operacja udana, brak danych do odesłania
    }

    [HttpDelete("{id}")] // 5. Usuń (DELETE)
    public async Task<ActionResult> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
