using SISALM.Logicas.Servicios.Logistica;
using SISALM.Repositorios.General;
using SISALM.Repositorios.Logistica;

namespace SISALM.Logicas.Logistica
{
    public class NotaEntradaLogica : INotaEntradaServicio
    {
        private readonly SISALMContexto _contexto;
        private NotaEntradaRepositorio? _repositorio = null;

        public NotaEntradaLogica(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public Task<List<NotaEntrada>> ListarPorPaginaAsync(NotaEntradaFiltro? filtro, int pageIndex, int pageSize)
        {
            _repositorio = new(_contexto);
            return _repositorio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
        }

        public Task<int> ContarAsync(NotaEntradaFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return _repositorio.ContarAsync(filtro);
        }

        public async Task<NotaEntrada?> BuscarPorIdAsync(int id, bool conDetalles = false)
        {
            _repositorio = new(_contexto);
            NotaEntradaMaterialRepositorio notaEntradaMaterialRepositorio = new(_contexto);

            NotaEntrada? entidad = await _repositorio.BuscarPorIdAsync(id);
            if (entidad != null && conDetalles)
                entidad.Materiales = await notaEntradaMaterialRepositorio.ListarAsync(new NotaEntradaMaterialFiltro { NotaEntradaId = id });

            return entidad;
        }

        public async Task GuardarAsync(NotaEntrada entidad)
        {
            AlmacenRepositorio almacenRepositorio;
            AlmacenMaterialRepositorio almacenMaterialRepositorio;

            try
            {
                _repositorio = new(_contexto);
                almacenRepositorio = new(_contexto);
                almacenMaterialRepositorio = new(_contexto);

                DateTime ahora = DateTime.Now;

                entidad.Registro = ahora;
                entidad.Anio = ahora.Year;
                entidad.Mes = ahora.Month;
                entidad.Estado = EstadoNotaEntrada.FINALIZADO;
                int cantidad = _repositorio.CountBy(x => x.Anio == entidad.Anio && x.Mes == entidad.Mes) + 1;
                entidad.Codigo = string.Format(Formatos.NOTAENTRADA_CODIGO, entidad.Anio, entidad.Mes, cantidad);

                _repositorio.Save(entidad);

                if (entidad.Materiales != null && entidad.Materiales.Count > 0)
                {
                    List<int> almacenIds = new(),
                        materialIds = new();

                    foreach (var item in entidad.Materiales)
                    {
                        almacenIds.Add(item.AlmacenId);
                        materialIds.Add(item.MaterialId);
                    }

                    List<Almacen> almacenes = almacenRepositorio.GetAllBy(x => almacenIds.Contains(x.Id));
                    List<AlmacenMaterial> almacenMateriales = almacenMaterialRepositorio.GetAllBy(x => almacenIds.Contains(x.AlmacenId) && materialIds.Contains(x.MaterialId));
                    Almacen almacen;
                    int index;

                    foreach (var item in entidad.Materiales)
                    {
                        almacen = almacenes.Single(x => x.Id == item.AlmacenId);

                        switch (almacen.Tipo)
                        {
                            case TipoAlmacen.PROMEDIO:
                                index = almacenMateriales.FindIndex(x => x.AlmacenId == item.AlmacenId && x.MaterialId == item.MaterialId);
                                if (index >= 0)
                                {
                                    almacenMateriales[index].Cantidad += item.Cantidad;

                                    if (almacenMateriales[index].Precio != item.Precio)
                                        almacenMateriales[index].Precio = (almacenMateriales[index].PrecioTotal + item.PrecioTotal) / (almacenMateriales[index].Cantidad + item.Cantidad);
                                }
                                else
                                {
                                    almacenMateriales.Add(new AlmacenMaterial
                                    {
                                        AlmacenId = item.AlmacenId,
                                        MaterialId = item.MaterialId,
                                        Cantidad = item.Cantidad,
                                        Precio = item.Precio
                                    });
                                }
                                break;
                            case TipoAlmacen.PEPS:
                            case TipoAlmacen.UEPS:
                                index = almacenMateriales.FindIndex(x => x.AlmacenId == item.AlmacenId && x.MaterialId == item.MaterialId && x.Periodo == ahora && x.Precio == item.Precio);
                                if (index >= 0) almacenMateriales[index].Cantidad += item.Cantidad;
                                else
                                {
                                    almacenMateriales.Add(new AlmacenMaterial
                                    {
                                        AlmacenId = item.AlmacenId,
                                        MaterialId = item.MaterialId,
                                        Periodo = ahora,
                                        Cantidad = item.Cantidad,
                                        Precio = item.Precio
                                    });
                                }
                                break;
                        }
                    }

                    foreach (var item in almacenMateriales)
                    {
                        if (item.Id > 0) almacenMaterialRepositorio.Update(item);
                        else almacenMaterialRepositorio.Save(item);
                    }
                }

                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception(Constantes.ERROR_GUARDAR);
            }
        }

        public async Task AnularAsync(NotaEntrada entidad)
        {
            try
            {
                _repositorio = new(_contexto);
                NotaEntrada? notaEntrada = await _repositorio.GetOneAsync(x => x.Id == entidad.Id);
                if (notaEntrada != null)
                {
                    notaEntrada.Estado = EstadoNotaEntrada.ANULADO;
                    _repositorio.Update(notaEntrada);

                    await _contexto.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw new Exception(Constantes.ERROR_ACTUALIZAR);
            }
        }
    }
}
