namespace SISALM.Repositorios.General
{
    public class MetaDatoRepositorio : BaseRepositorio<MetaDato>
    {
        public MetaDatoRepositorio(SISALMContexto contexto) : base(contexto) { }

        public Task<List<MetaDato>> ListarPorPaginaAsync(MetaDatoFiltro? filtro, int pageSize, int pageIndex)
            => QueryLista(filtro).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        public Task<int> ContarAsync(MetaDatoFiltro? filtro) => QueryLista(filtro).CountAsync();

        #region Funciones

        private IQueryable<MetaDato> QueryLista(MetaDatoFiltro? filtro = null)
        {
            var source = _contexto.MetaDato.AsQueryable();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Codigo)) source = source.Where(x => x.Codigo != null && x.Codigo.Contains(filtro.Codigo));
                if (!string.IsNullOrEmpty(filtro.Nombre)) source = source.Where(x => x.Nombre.Contains(filtro.Nombre));
                if (filtro.Activo.HasValue) source = source.Where(x => x.Activo == filtro.Activo);
            }

            return source;
        }

        #endregion
    }
}
