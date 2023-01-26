namespace SISALM.Logicas.Servicios.Logistica
{
    public interface INotaSalidaServicio
    {
        Task<List<NotaSalida>> ListarPorPaginaAsync(NotaSalidaFiltro? filtro, int pageIndex, int pageSize);
        Task<int> ContarAsync(NotaSalidaFiltro? filtro);
        Task<NotaSalida?> BuscarPorIdAsync(int id, bool conDetalles = false);

        Task GuardarAsync(NotaSalida entidad);
        Task AnularAsync(NotaSalida entidad);
    }
}
