using SISALM.Logicas.Servicios.General;
using SISALM.Repositorios.General;

namespace SISALM.Logicas.General
{
    public class MaterialLogica : IMaterialServicio
    {
        private readonly SISALMContexto _contexto;
        private MaterialRepositorio? _repositorio = null;

        public MaterialLogica(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Material>> ListarPorPaginaAsync(MaterialFiltro? filtro, int pageSize, int pageIndex)
        {
            _repositorio = new(_contexto);
            return await _repositorio.ListarPorPaginaAsync(filtro, pageSize, pageIndex);
        }

        public async Task<int> ContarAsync(MaterialFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return await _repositorio.ContarAsync(filtro);
        }

        public async Task GuardarAsync(Material entidad)
        {
            _repositorio = new(_contexto);
            _repositorio.Save(entidad);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Material entidad)
        {
            _repositorio = new(_contexto);

            Material? item = await _repositorio.GetOneAsync(x => x.Id == entidad.Id);
            if (item != null)
            {
                item.Codigo = entidad.Codigo;
                item.CodigoPersonalizado = entidad.CodigoPersonalizado;
                item.Clasificacion = entidad.Clasificacion;
                item.UnidadMedidaId = entidad.UnidadMedidaId;
                item.Nombre = entidad.Nombre;
                item.Activo = entidad.Activo;

                _repositorio.Save(item);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
