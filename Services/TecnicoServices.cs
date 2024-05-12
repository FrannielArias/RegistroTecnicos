using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TecnicoServices
{
    private readonly Contexto _contexto;

    public TecnicoServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Extiste(int TecnicosId)
    {
        return await _contexto.Tecnicos
            .AnyAsync(c => c.TecnicosId == TecnicosId);
    }

    public async Task<bool> Guardar(Tecnicos tecnicos)
    {
        if (!await Extiste(tecnicos.TecnicosId))
            return await Insertar(tecnicos);
        else
            return await Modificar(tecnicos);

    }

    public async Task<bool> Insertar(Tecnicos tecnicos)
    {
        _contexto.Add(tecnicos);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Tecnicos tecnicos)
    {
        _contexto.Update(tecnicos);
        return await _contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Tecnicos tecnicos)
    {
        var cantidad = await _contexto.Tecnicos
            .Where(c => c.TecnicosId == tecnicos.TecnicosId)
            .ExecuteDeleteAsync();
        return cantidad > 0;
    }

    public async Task<Tecnicos?> BuscarNombre(string nombre)
    {
        return await _contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombre.ToLower());
    }  
    
    public async Task<Tecnicos?> BuscarSueldo(double sueldoHora)
    {
        return await _contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.SueldoHora == sueldoHora);
    }


    public async Task<Tecnicos?> Buscar(int TecnicosId)
    {
        return await _contexto.Tecnicos.AsNoTracking().FirstOrDefaultAsync(C => C.TecnicosId == TecnicosId);
    }

    public List<Tecnicos> Listar(Expression<Func<Tecnicos, bool>> Criterio)
    {
        return _contexto.Tecnicos
            .Where(Criterio)
            .AsNoTracking()
            .ToList();
    }
}
