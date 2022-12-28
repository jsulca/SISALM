using SISALM.Logicas.Servicios.Logistica;
using SISALM.Repositorios.Logistica;

namespace SISALM.Logicas.Logistica
{
    public class NotaEntradaLogica : INotaEntradaServicio
    {
        private readonly SISALMContexto _contexto;
        private NotaEntradaRepositorio? _repositorio = null;

        public NotaEntradaLogica(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public Task<List<NotaEntrada>> ListarPorPaginaAsync(NotaEntradaFiltro? filtro, int pageIndex, int pageSize)
        {
            _repositorio = new(_contexto);
            return _repositorio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
        }

        public Task<int> ContarAsync(NotaEntradaFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return _repositorio.ContarAsync(filtro);
        }

        public async Task<NotaEntrada?> BuscarPorIdAsync(int id, bool conDetalles = false)
        {
            _repositorio = new(_contexto);
            NotaEntradaMaterialRepositorio notaEntradaMaterialRepositorio = new(_contexto);

            NotaEntrada? entidad = await _repositorio.BuscarPorIdAsync(id);
            if (entidad != null && conDetalles)
                entidad.Materiales = await notaEntradaMaterialRepositorio.ListarAsync(new NotaEntradaMaterialFiltro { NotaEntradaId = id });

            return entidad;
        }

        public Task GuardarAsync(NotaEntrada entidad)
        {
            throw new NotImplementedException();
        }

        public Task AnularAsync(NotaEntrada entidad)
        {
            throw new NotImplementedException();
        }
    }
}
