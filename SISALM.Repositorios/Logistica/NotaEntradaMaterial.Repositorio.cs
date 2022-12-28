using SISALM.Entidades.Filtros.Logistica;

namespace SISALM.Repositorios.Logistica
{
    public class NotaEntradaMaterialRepositorio : BaseRepositorio<NotaEntradaMaterial>
    {
        public NotaEntradaMaterialRepositorio(SISALMContexto contexto) : base(contexto) { }

        public async Task<List<NotaEntradaMaterial>> ListarAsync(NotaEntradaMaterialFiltro? filtro)
        {
            List<NotaEntradaMaterial> lista = await QueryLista(filtro).ToListAsync();

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

        private IQueryable<NotaEntradaMaterial> QueryLista(NotaEntradaMaterialFiltro? filtro = null)
        {
            var source = _contexto.NotaEntradaMaterial.Include(x => x.Material).AsQueryable();

            if (filtro != null)
            {
                if (filtro.NotaEntradaId.HasValue) source = source.Where(x => x.NotaEntradaId == filtro.NotaEntradaId);
                if (filtro.NotaEntradaIds != null && filtro.NotaEntradaIds.Length > 0) source = source.Where(x => filtro.NotaEntradaIds.Contains(x.NotaEntradaId));
            }

            return source;
        }

        #endregion
    }
}
