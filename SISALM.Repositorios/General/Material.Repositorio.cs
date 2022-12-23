namespace SISALM.Repositorios.General
{
    public class MaterialRepositorio : BaseRepositorio<Material>
    {
        public MaterialRepositorio(SISALMContexto contexto) : base(contexto) { }

        public async Task<List<Material>> ListarPorPaginaAsync(MaterialFiltro? filtro, int pageIndex, int pageSize)
        {
            List<Material> lista = await QueryLista(filtro).OrderByDescending(x => x.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            if (lista.Count > 0)
            {
                int[] unidadMedidaIds = lista.Select(x => x.UnidadMedidaId).ToArray();
                List<MetaDato> metaDatos = await _contexto.MetaDato.Where(x => unidadMedidaIds.Contains(x.Id)).ToListAsync();
                foreach (var item in lista)
                    item.UnidadMedida = metaDatos.SingleOrDefault(x => x.Id == item.UnidadMedidaId);
            }
            return lista;
        }

        public Task<int> ContarAsync(MaterialFiltro? filtro) => QueryLista(filtro).CountAsync();

        public async Task<Material?> BuscarPorIdAsync(int id)
        {
            var source = _contexto.Material.Where(x => x.Id == id);
            Material? entidad = await source.SingleOrDefaultAsync();

            if (entidad != null)
                entidad.UnidadMedida = await _contexto.MetaDato.SingleOrDefaultAsync(x => x.Id == entidad.UnidadMedidaId);

            return entidad;
        }

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
