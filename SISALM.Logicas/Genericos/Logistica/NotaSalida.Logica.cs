using SISALM.Logicas.Servicios.Logistica;
using SISALM.Repositorios.General;
using SISALM.Repositorios.Logistica;

namespace SISALM.Logicas.Logistica
{
    public class NotaSalidaLogica : INotaSalidaServicio
    {
        private readonly SISALMContexto _contexto;
        private NotaSalidaRepositorio? _repositorio = null;

        public NotaSalidaLogica(SISALMContexto contexto)
        {
            _contexto = contexto;
        }

        public Task<List<NotaSalida>> ListarPorPaginaAsync(NotaSalidaFiltro? filtro, int pageIndex, int pageSize)
        {
            _repositorio = new(_contexto);
            return _repositorio.ListarPorPaginaAsync(filtro, pageIndex, pageSize);
        }

        public Task<int> ContarAsync(NotaSalidaFiltro? filtro)
        {
            _repositorio = new(_contexto);
            return _repositorio.ContarAsync(filtro);
        }

        public async Task<NotaSalida?> BuscarPorIdAsync(int id, bool conDetalles = false)
        {
            _repositorio = new(_contexto);
            NotaSalidaMaterialRepositorio notaSalidaMaterialRepositorio = new(_contexto);

            NotaSalida? entidad = await _repositorio.BuscarPorIdAsync(id);
            if (entidad != null && conDetalles)
                entidad.Materiales = await notaSalidaMaterialRepositorio.ListarAsync(new NotaSalidaMaterialFiltro { NotaSalidaId = id });

            return entidad;
        }

        public async Task GuardarAsync(NotaSalida entidad)
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
                entidad.Estado = entidad.Estado;
                int cantidad = _repositorio.CountBy(x => x.Anio == entidad.Anio && x.Mes == entidad.Mes) + 1;
                entidad.Codigo = string.Format(Formatos.NOTASALIDA_CODIGO, entidad.Anio, entidad.Mes, cantidad);

                _repositorio.Save(entidad);

                //if (entidad.Materiales != null && entidad.Materiales.Count > 0)
                //{
                //    List<int> almacenIds = new(),
                //        materialIds = new();

                //    foreach (var item in entidad.Materiales)
                //    {
                //        almacenIds.Add(item.AlmacenId);
                //        materialIds.Add(item.MaterialId);
                //    }

                //    List<Almacen> almacenes = almacenRepositorio.GetAllBy(x => almacenIds.Contains(x.Id));
                //    List<AlmacenMaterial> almacenMateriales = almacenMaterialRepositorio.GetAllBy(x => almacenIds.Contains(x.AlmacenId) && materialIds.Contains(x.MaterialId));
                //    Almacen almacen;
                //    int index;

                //    foreach (var item in entidad.Materiales)
                //    {
                //        almacen = almacenes.Single(x => x.Id == item.AlmacenId);

                //        switch (almacen.Tipo)
                //        {
                //            case TipoAlmacen.PROMEDIO:
                //                index = almacenMateriales.FindIndex(x => x.AlmacenId == item.AlmacenId && x.MaterialId == item.MaterialId);
                //                if (index >= 0)
                //                {
                //                    almacenMateriales[index].Cantidad += item.Cantidad;

                //                    //if (almacenMateriales[index].Precio != item.Precio)
                //                    //    almacenMateriales[index].Precio = (almacenMateriales[index].PrecioTotal + item.PrecioTotal) / (almacenMateriales[index].Cantidad + item.Cantidad);
                //                }
                //                else
                //                {
                //                    almacenMateriales.Add(new AlmacenMaterial
                //                    {
                //                        AlmacenId = item.AlmacenId,
                //                        MaterialId = item.MaterialId,
                //                        Cantidad = item.Cantidad,
                //                        //Precio = item.Precio
                //                    });
                //                }
                //                break;
                //            case TipoAlmacen.PEPS:
                //            case TipoAlmacen.UEPS:
                //                index = almacenMateriales.FindIndex(x => x.AlmacenId == item.AlmacenId && x.MaterialId == item.MaterialId && x.Periodo == ahora);
                //                if (index >= 0) almacenMateriales[index].Cantidad += item.Cantidad;
                //                else
                //                {
                //                    almacenMateriales.Add(new AlmacenMaterial
                //                    {
                //                        AlmacenId = item.AlmacenId,
                //                        MaterialId = item.MaterialId,
                //                        Periodo = ahora,
                //                        Cantidad = item.Cantidad,
                //                        //Precio = item.Precio
                //                    });
                //                }
                //                break;
                //        }
                //    }

                //    //foreach (var item in almacenMateriales)
                //    //{
                //    //    if (item.Id > 0) almacenMaterialRepositorio.Update(item);
                //    //    else almacenMaterialRepositorio.Save(item);
                //    //}
                //}

                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception(Constantes.ERROR_GUARDAR);
            }
        }

        public async Task AnularAsync(NotaSalida entidad)
        {
            try
            {
                _repositorio = new(_contexto);
                NotaSalida? notaSalida = await _repositorio.GetOneAsync(x => x.Id == entidad.Id);
                if (notaSalida != null)
                {
                    notaSalida.Estado = EstadoNotaSalida.ANULADO;
                    _repositorio.Update(notaSalida);

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
