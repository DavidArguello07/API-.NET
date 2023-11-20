using webapi.Models;

namespace webapi.Services;

public class TareaService : ITareaService
{

    protected readonly TareasContext _context;

    public TareaService(TareasContext dbcontext)
    {
        _context = dbcontext;
    }
    public IEnumerable<Tarea> Get()
    {
        return _context.Tareas;
    }
    public async Task Save(Tarea tarea)
    {
        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var tareaActual = _context.Tareas.Find(id);
        if (tareaActual != null)
        {
            _context.Tareas.Remove(tareaActual);
            await _context.SaveChangesAsync();
        }

    }
    public async Task Update(Guid id, Tarea tarea)
    {

        var tareaActual = _context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = tarea.FechaCreacion;
            tareaActual.Categoria = tarea.Categoria;

            await _context.SaveChangesAsync();
        }
    }
}


public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}