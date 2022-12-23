namespace SISALM.Logicas.Servicios.General
{
    public interface IAlmacenServicio
    {
        Task<List<Almacen>> ListarPorPaginaAsync(AlmacenFiltro? filtro, int pageIndex, int pageSize);
        Task<int> ContarAsync(AlmacenFiltro? filtro);
        Task<Almacen?> BuscarPorIdAsync(int id);
        Task GuardarAsync(Almacen entidad);
        Task ActualizarAsync(Almacen entidad);
    }
}
