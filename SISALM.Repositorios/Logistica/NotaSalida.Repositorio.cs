using SISALM.Entidades.Filtros.Logistica;

namespace SISALM.Repositorios.Logistica
{
    public class NotaSalidaRepositorio : BaseRepositorio<NotaSalida>
    {
        public NotaSalidaRepositorio(SISALMContexto contexto) : base(contexto) { }

        public Task<List<NotaSalida>> ListarPorPaginaAsync(NotaSalidaFiltro? filtro, int pageIndex, int pageSize)
            => QueryLista(filtro).OrderByDescending(x => x.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        public Task<int> ContarAsync(NotaSalidaFiltro? filtro) => QueryLista(filtro).CountAsync();

        public Task<NotaSalida?> BuscarPorIdAsync(int id) => 
            _contexto.NotaSalida.Include(x => x.NotaEntrada).Where(x => x.Id == id).SingleOrDefaultAsync();

        #region Funciones

        private IQueryable<NotaSalida> QueryLista(NotaSalidaFiltro? filtro = null)
        {
            var source = _contexto.NotaSalida.AsQueryable();

            if (filtro != null)
            {
                if (filtro.Id.HasValue) source = source.Where(x => x.Id == filtro.Id);
                if (filtro.NotaEntradaId.HasValue) source = source.Where(x => x.NotaEntradaId == filtro.NotaEntradaId);
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
