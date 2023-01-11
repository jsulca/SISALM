using SISALM.Logicas.Servicios.Logistica;
using SISALM.Repositorios.Logistica;

namespace SISALM.Logicas.Logistica
{
    public class AlmacenMaterialLogica : IAlmacenMaterialServicio
    {
        private readonly SISALMContexto _contexto;
        private AlmacenMaterialRepositorio? _repositorio = null;

        public AlmacenMaterialLogica(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public Task<List<AlmacenMaterial>> ListarPorPaginaAsync(AlmacenMaterialFiltro? filtro, int pageIndex, int pageSize)
        {
            _repositorio = new(_contexto);
            return _repositorio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
        }

        public Task<int> ContarAsync(AlmacenMaterialFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return _repositorio.ContarAsync(filtro);
        }

        public Task<List<AlmacenMaterial>> ListarAsync(AlmacenMaterialFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return _repositorio.ListarAsync(filtro);
        }
    }
}
