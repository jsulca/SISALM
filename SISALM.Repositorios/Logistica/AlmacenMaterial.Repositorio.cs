using SISALM.Entidades.Filtros.Logistica;

namespace SISALM.Repositorios.Logistica
{
    public class AlmacenMaterialRepositorio : BaseRepositorio<AlmacenMaterial>
    {
        public AlmacenMaterialRepositorio(SISALMContexto contexto) : base(contexto) { }

        public async Task<List<AlmacenMaterial>> ListarPorPaginaAsync(AlmacenMaterialFiltro? filtro, int pageIndex, int pageSize)
        {
            List<AlmacenMaterial> lista = await QueryLista(filtro).OrderByDescending(x => x.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            if (lista.Count > 0)
            {
                int[] metaDatoIds = lista.Select(x => x.Material!.UnidadMedidaId).ToArray();
                List<MetaDato> metaDatos = await _contexto.MetaDato.Where(x => metaDatoIds.Contains(x.Id)).ToListAsync();

                foreach (var item in lista)
                    item.Material!.UnidadMedida = metaDatos.SingleOrDefault(x => x.Id == item.Material!.UnidadMedidaId);
            }

            return lista;
        }

        public Task<int> ContarAsync(AlmacenMaterialFiltro? filtro) => QueryLista(filtro).CountAsync();

        #region Funciones

        private IQueryable<AlmacenMaterial> QueryLista(AlmacenMaterialFiltro? filtro = null)
        {
            var source = _contexto.AlmacenMaterial
                                .Include(x => x.Almacen)
                                .Include(x => x.Material)
                                .AsQueryable();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.AlmacenCodigo)) source = source.Where(x => x.Almacen!.Codigo != null && x.Almacen!.Codigo.Contains(filtro.AlmacenCodigo));
                if (!string.IsNullOrEmpty(filtro.AlmacenNombre)) source = source.Where(x => x.Almacen!.Nombre.Contains(filtro.AlmacenNombre));
                if (!string.IsNullOrEmpty(filtro.MaterialCodigo)) source = source.Where(x => x.Material!.Codigo.Contains(filtro.MaterialCodigo));
                if (!string.IsNullOrEmpty(filtro.MaterialNombre)) source = source.Where(x => x.Material!.Nombre.Contains(filtro.MaterialNombre));
                if (filtro.MaterialUnidadMedidaId.HasValue) source = source.Where(x => x.Material!.UnidadMedidaId == filtro.MaterialUnidadMedidaId);
                if (filtro.AlmacenTipo.HasValue) source = source.Where(x => x.Almacen!.Tipo == filtro.AlmacenTipo);
            }

            return source;
        }

        #endregion
    }
}
