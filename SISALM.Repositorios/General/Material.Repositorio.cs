namespace SISALM.Repositorios.General
{
    public class MaterialRepositorio : BaseRepositorio<Material>
    {
        public MaterialRepositorio(SISALMContexto contexto) : base(contexto) { }

        public Task<List<Material>> ListarPorPaginaAsync(MaterialFiltro? filtro, int pageSize, int pageIndex)
            => QueryLista(filtro).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        public Task<int> ContarAsync(MaterialFiltro? filtro) => QueryLista(filtro).CountAsync();

        #region Funciones

        private IQueryable<Material> QueryLista(MaterialFiltro? filtro = null)
        {
            var source = _contexto.Material.AsQueryable();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.CodigoPersonalizado)) source = source.Where(x => x.CodigoPersonalizado != null && x.CodigoPersonalizado.Contains(filtro.CodigoPersonalizado));
                if (!string.IsNullOrEmpty(filtro.Codigo)) source = source.Where(x => x.Codigo.Contains(filtro.Codigo));
                if (!string.IsNullOrEmpty(filtro.Nombre)) source = source.Where(x => x.Nombre.Contains(filtro.Nombre));
                if (filtro.Activo.HasValue) source = source.Where(x => x.Activo == filtro.Activo);
                if (filtro.Clasificacion.HasValue) source = source.Where(x => x.Clasificacion == filtro.Clasificacion);
                if (filtro.UnidadMedidaId.HasValue) source = source.Where(x => x.UnidadMedidaId == filtro.UnidadMedidaId);
            }

            return source;
        }

        #endregion
    }
}
