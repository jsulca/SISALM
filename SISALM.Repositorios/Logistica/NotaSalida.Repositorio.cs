using SISALM.Entidades.Filtros.Logistica;

namespace SISALM.Repositorios.Logistica
{
    public class NotaEntradaRepositorio : BaseRepositorio<NotaEntrada>
    {
        public NotaEntradaRepositorio(SISALMContexto contexto) : base(contexto) { }

        public Task<List<NotaEntrada>> ListarPorPaginaAsync(NotaEntradaFiltro? filtro, int pageIndex, int pageSize)
            => QueryLista(filtro).OrderByDescending(x => x.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        public Task<int> ContarAsync(NotaEntradaFiltro? filtro) => QueryLista(filtro).CountAsync();

        public Task<NotaEntrada?> BuscarPorIdAsync(int id) => 
            _contexto.NotaEntrada.Include(x => x.NotaSalida).Where(x => x.Id == id).SingleOrDefaultAsync();

        #region Funciones

        private IQueryable<NotaEntrada> QueryLista(NotaEntradaFiltro? filtro = null)
        {
            var source = _contexto.NotaEntrada.AsQueryable();

            if (filtro != null)
            {
                if (filtro.Id.HasValue) source = source.Where(x => x.Id == filtro.Id);
                if (filtro.NotaSalidaId.HasValue) source = source.Where(x => x.NotaSalidaId == filtro.NotaSalidaId);
                if (!string.IsNullOrEmpty(filtro.Codigo)) source = source.Where(x => x.Codigo.Contains(filtro.Codigo));
                if (!string.IsNullOrEmpty(filtro.Descripcion)) source = source.Where(x => x.Descripcion.Contains(filtro.Descripcion));
                if (filtro.Estado.HasValue) source = source.Where(x => x.Estado == filtro.Estado);
                if (filtro.Tipo.HasValue) source = source.Where(x => x.Tipo == filtro.Tipo);
                if (filtro.Anio.HasValue) source = source.Where(x => x.Anio == filtro.Anio);
                if (filtro.Mes.HasValue) source = source.Where(x => x.Mes == filtro.Mes);
                if (!string.IsNullOrEmpty(filtro.NroComprobante)) source = source.Where(x => x.NroComprobante != null &&  x.NroComprobante.Contains(filtro.NroComprobante));
            }

            return source;
        }

        #endregion
    }
}
