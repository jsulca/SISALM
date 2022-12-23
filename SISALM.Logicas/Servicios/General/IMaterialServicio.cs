using System.Linq.Expressions;

namespace SISALM.Logicas.Servicios.General
{
    public interface IMaterialServicio
    {
        Task<List<Material>> ListarPorPaginaAsync(MaterialFiltro? filtro, int pageIndex, int pageSize);
        Task<int> ContarAsync(MaterialFiltro? filtro);
        Task<Material?> BuscarPorIdAsync(int id);
        Task<int> CountByAsync(Expression<Func<Material, bool>> predicate);

        Task GuardarAsync(Material entidad);
        Task ActualizarAsync(Material entidad);
    }
}
