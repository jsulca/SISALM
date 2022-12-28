namespace SISALM.Repositorios.General
{
    public class AlmacenRepositorio : BaseRepositorio<Almacen>
    {
        public AlmacenRepositorio(SISALMContexto contexto) : base(contexto) { }

        public Task<List<Almacen>> ListarPorPaginaAsync(AlmacenFiltro? filtro, int pageIndex, int pageSize)
            => QueryLista(filtro).OrderByDescending(x => x.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        public Task<int> ContarAsync(AlmacenFiltro? filtro) => QueryLista(filtro).CountAsync();

        public Task<List<Almacen>> ListarAsync(AlmacenFiltro? filtro) => QueryLista(filtro).ToListAsync();

        #region Funciones

        private IQueryable<Almacen> QueryLista(AlmacenFiltro? filtro = null)
        {
            var source = _contexto.Almacen.AsQueryable();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Codigo)) source = source.Where(x => x.Codigo != null && x.Codigo.Contains(filtro.Codigo));
                if (!string.IsNullOrEmpty(filtro.Direccion)) source = source.Where(x => x.Direccion != null && x.Direccion.Contains(filtro.Direccion));
                if (!string.IsNullOrEmpty(filtro.Nombre)) source = source.Where(x => x.Nombre.Contains(filtro.Nombre));
                if (filtro.Activo.HasValue) source = source.Where(x => x.Activo == filtro.Activo);
                if (filtro.Tipo.HasValue) source = source.Where(x => x.Tipo == filtro.Tipo);
            }

            return source;
        }

        #endregion
    }
}
