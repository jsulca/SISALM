using SISALM.Entidades.Filtros.Logistica;

namespace SISALM.Repositorios.Logistica
{
    public class NotaSalidaMaterialRepositorio : BaseRepositorio<NotaSalidaMaterial>
    {
        public NotaSalidaMaterialRepositorio(SISALMContexto contexto) : base(contexto) { }

        public async Task<List<NotaSalidaMaterial>> ListarAsync(NotaSalidaMaterialFiltro? filtro)
        {
            List<NotaSalidaMaterial> lista = await QueryLista(filtro).ToListAsync();

            if (lista.Count > 0)
            {
                int[] metaDatoIds = lista.Select(x => x.Material!.UnidadMedidaId).ToArray();
                List<MetaDato> metaDatos = await _contexto.MetaDato.Where(x => metaDatoIds.Contains(x.Id)).ToListAsync();
                foreach (var item in lista)
                    item.Material!.UnidadMedida = metaDatos.Single(x => x.Id == item.Material!.UnidadMedidaId);
            }

            return lista;
        }

        #region Funciones

        private IQueryable<NotaSalidaMaterial> QueryLista(NotaSalidaMaterialFiltro? filtro = null)
        {
            var source = _contexto.NotaSalidaMaterial
                        .Include(x => x.Material)
                        .Include(x => x.Almacen)
                        .AsQueryable();

            if (filtro != null)
            {
                if (filtro.NotaSalidaId.HasValue) source = source.Where(x => x.NotaSalidaId == filtro.NotaSalidaId);
                if (filtro.NotaSalidaIds != null && filtro.NotaSalidaIds.Length > 0) source = source.Where(x => filtro.NotaSalidaIds.Contains(x.NotaSalidaId));
            }

            return source;
        }

        #endregion
    }
}
