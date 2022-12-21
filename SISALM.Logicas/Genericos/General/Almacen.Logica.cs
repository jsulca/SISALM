using SISALM.Logicas.Servicios.General;
using SISALM.Repositorios.General;

namespace SISALM.Logicas.General
{
    public class AlmacenLogica : IAlmacenServicio
    {
        private readonly SISALMContexto _contexto;
        private AlmacenRepositorio? _repositorio = null;

        public AlmacenLogica(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Almacen>> ListarPorPaginaAsync(AlmacenFiltro? filtro, int pageSize, int pageIndex)
        {
            _repositorio = new(_contexto);
            return await _repositorio.ListarPorPaginaAsync(filtro, pageSize, pageIndex);
        }

        public async Task<int> ContarAsync(AlmacenFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return await _repositorio.ContarAsync(filtro);
        }

        public async Task GuardarAsync(Almacen entidad)
        {
            _repositorio = new(_contexto);
            _repositorio.Save(entidad);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Almacen entidad)
        {
            _repositorio = new(_contexto);

            Almacen? item = await _repositorio.GetOneAsync(x => x.Id == entidad.Id);
            if (item != null)
            {
                item.Codigo = entidad.Codigo;
                item.Nombre = entidad.Nombre;
                item.Activo = entidad.Activo;
                item.Direccion = entidad.Direccion;

                _repositorio.Save(item);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
