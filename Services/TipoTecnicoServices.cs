using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TipoTecnicoServices
    {
        private readonly Contexto _contexto;

        public TipoTecnicoServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int tipoId)
        {
            return await _contexto.TipoTecnicos
                .AnyAsync(c => c.TipoId == tipoId);
        }

        public async Task<bool> Guardar(TipoTecnico tipoTecnico)
        {
            if (!await Existe(tipoTecnico.TipoId))
                return await Insertar(tipoTecnico);
            else
                return await Modificar(tipoTecnico);

        }

        public async Task<bool> Insertar(TipoTecnico tipoTecnico)
        {
            _contexto.Add(tipoTecnico);
            return await _contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(TipoTecnico tipoTecnico)
        {
            _contexto.Update(tipoTecnico);
            return await _contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(TipoTecnico tipoTecnico)
        {
            var cantidad = await _contexto.TipoTecnicos
                .Where(c => c.TipoId == tipoTecnico.TipoId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public async Task<TipoTecnico?> BuscarDescripcion(string Descripcion)
        {
            return await _contexto.TipoTecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Descripcion.ToLower() == Descripcion.ToLower());
        }

        public async Task<TipoTecnico?> Buscar(int TipoId)
        {
            return await _contexto.TipoTecnicos.AsNoTracking().FirstOrDefaultAsync(C => C.TipoId == TipoId);
        }

        public List<TipoTecnico> Listar(Expression<Func<TipoTecnico, bool>> Criterio)
        {
            return _contexto.TipoTecnicos
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}
