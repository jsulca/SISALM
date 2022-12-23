namespace SISALM.Repositorios.General
{
    public class MetaDatoRepositorio : BaseRepositorio<MetaDato>
    {
        public MetaDatoRepositorio(SISALMContexto contexto) : base(contexto) { }

        public Task<List<MetaDato>> ListarPorPaginaAsync(MetaDatoFiltro? filtro, int pageIndex, int pageSize)
            => QueryLista(filtro).OrderByDescending(x => x.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        public Task<List<MetaDato>> ListarAsync(MetaDatoFiltro? filtro)
            => QueryLista(filtro).ToListAsync();

        public Task<int> ContarAsync(MetaDatoFiltro? filtro) => QueryLista(filtro).CountAsync();

        #region Funciones

        private IQueryable<MetaDato> QueryLista(MetaDatoFiltro? filtro = null)
        {
            var source = _contexto.MetaDato.AsQueryable();

            if (filtro != null)
            {
                if (filtro.Tipo.HasValue) source = source.Where(x => x.Tipo == filtro.Tipo);
                if (!string.IsNullOrEmpty(filtro.Codigo)) source = source.Where(x => x.Codigo != null && x.Codigo.Contains(filtro.Codigo));
                if (!string.IsNullOrEmpty(filtro.Nombre)) source = source.Where(x => x.Nombre.Contains(filtro.Nombre));
                if (filtro.Activo.HasValue) source = source.Where(x => x.Activo == filtro.Activo);
                if (filtro.Tipos != null && filtro.Tipos.Length > 0) source = source.Where(x => filtro.Tipos.Contains(x.Tipo));
            }

            return source;
        }

        #endregion
    }
}
