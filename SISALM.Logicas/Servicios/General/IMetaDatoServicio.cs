namespace SISALM.Logicas.Servicios.General
{
    public interface IMetaDatoServicio
    {
        Task<List<MetaDato>> ListarPorPaginaAsync(MetaDatoFiltro? filtro, int pageSize, int pageIndex);
        Task<int> ContarAsync(MetaDatoFiltro? filtro);
        Task GuardarAsync(MetaDato entidad);
        Task ActualizarAsync(MetaDato entidad);
    }
}
