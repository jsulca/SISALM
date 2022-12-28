namespace SISALM.Logicas.Servicios.Logistica
{
    public interface INotaEntradaServicio
    {
        Task<List<NotaEntrada>> ListarPorPaginaAsync(NotaEntradaFiltro? filtro, int pageIndex, int pageSize);
        Task<int> ContarAsync(NotaEntradaFiltro? filtro);
        Task<NotaEntrada?> BuscarPorIdAsync(int id, bool conDetalles = false);

        Task GuardarAsync(NotaEntrada entidad);
        Task AnularAsync(NotaEntrada entidad);
    }
}
