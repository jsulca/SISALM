namespace SISALM.Logicas.Servicios.Logistica
{
    public interface IAlmacenMaterialServicio
    {
        Task<List<AlmacenMaterial>> ListarPorPaginaAsync(AlmacenMaterialFiltro? filtro, int pageIndex, int pageSize);
        Task<int> ContarAsync(AlmacenMaterialFiltro? filtro);
    }
}
