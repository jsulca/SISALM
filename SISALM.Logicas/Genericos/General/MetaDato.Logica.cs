using SISALM.Logicas.Servicios.General;
using SISALM.Repositorios.General;

namespace SISALM.Logicas.General
{
    public class MetaDatoLogica : IMetaDatoServicio
    {
        private readonly SISALMContexto _contexto;
        private MetaDatoRepositorio? _repositorio = null;

        public MetaDatoLogica(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<MetaDato>> ListarPorPaginaAsync(MetaDatoFiltro? filtro, int pageIndex, int pageSize)
        {
            _repositorio = new(_contexto);
            return await _repositorio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
        }

        public async Task<List<MetaDato>> ListarAsync(MetaDatoFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return await _repositorio.ListarAsync(filtro);
        }

        public async Task<int> ContarAsync(MetaDatoFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return await _repositorio.ContarAsync(filtro);
        }

        public async Task<MetaDato?> BuscarPorIdAsync(int id)
        {
            _repositorio = new(_contexto);
            return await _repositorio.GetOneAsync(x => x.Id == id);
        }

        public async Task GuardarAsync(MetaDato entidad)
        {
            _repositorio = new(_contexto);
            _repositorio.Save(entidad);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarAsync(MetaDato entidad)
        {
            _repositorio = new(_contexto);

            MetaDato? item = await _repositorio.GetOneAsync(x => x.Id == entidad.Id);
            if (item != null)
            {
                item.Codigo = entidad.Codigo;
                item.Nombre = entidad.Nombre;
                item.Activo = entidad.Activo;

                _repositorio.Update(item);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
