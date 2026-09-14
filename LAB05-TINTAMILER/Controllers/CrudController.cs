using LAB05_TINTAMILER.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TINTAMILER.Controllers;

[ApiController]
public abstract class CrudController<T> : ControllerBase where T : class
{
    private readonly ICrudService<T> _service;

    protected CrudController(ICrudService<T> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<T>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<T>> Create(T item)
    {
        var createdItem = await _service.CreateAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = GetPrimaryKeyValue(createdItem) }, createdItem);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, T item)
    {
        await _service.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }

    private static object? GetPrimaryKeyValue(T item)
    {
        var keyProperty = typeof(T).GetProperties()
            .FirstOrDefault(property => property.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase));

        return keyProperty?.GetValue(item);
    }
}
