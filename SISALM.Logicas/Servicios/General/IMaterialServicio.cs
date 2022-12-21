namespace SISALM.Logicas.Servicios.General
{
    public interface IMaterialServicio
    {
        Task<List<Material>> ListarPorPaginaAsync(MaterialFiltro? filtro, int pageSize, int pageIndex);
        Task<int> ContarAsync(MaterialFiltro? filtro);
        Task GuardarAsync(Material entidad);
        Task ActualizarAsync(Material entidad);
    }
}
