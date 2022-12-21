namespace SISALM.Logicas.Servicios.General
{
    public interface IAlmacenServicio
    {
        Task<List<Almacen>> ListarPorPaginaAsync(AlmacenFiltro? filtro, int pageSize, int pageIndex);
        Task<int> ContarAsync(AlmacenFiltro? filtro);
        Task GuardarAsync(Almacen entidad);
        Task ActualizarAsync(Almacen entidad);
    }
}
