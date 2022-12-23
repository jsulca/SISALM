namespace SISALM.Logicas.Servicios.General
{
    public interface IMetaDatoServicio
    {
        Task<List<MetaDato>> ListarPorPaginaAsync(MetaDatoFiltro? filtro, int pageIndex, int pageSize);
        Task<List<MetaDato>> ListarAsync(MetaDatoFiltro? filtro);
        Task<int> ContarAsync(MetaDatoFiltro? filtro);
        Task<MetaDato?> BuscarPorIdAsync(int id);

        Task GuardarAsync(MetaDato entidad);
        Task ActualizarAsync(MetaDato entidad);
    }
}
