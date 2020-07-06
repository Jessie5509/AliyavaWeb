using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MDetalle
    {
        public static DtoDetallePedido MapToDto(DetallePedido entity)
        {
            DtoDetallePedido dto = new DtoDetallePedido();
            dto.CantidadPreparar = entity.CantidadPreparar;
            dto.idPedido = entity.idPedido;
            dto.idProducto = entity.idProducto;
            dto.PrecioU = entity.PrecioU;
            dto.UbicacionPro = entity.UbicacionPro;

            return dto;
        }

        public static DetallePedido MapToEntity(DtoDetallePedido dto)
        {
            DetallePedido entity = new DetallePedido();
            entity.CantidadPreparar = dto.CantidadPreparar;
            entity.idPedido = dto.idPedido;
            entity.idProducto = dto.idProducto;
            entity.PrecioU = dto.PrecioU;
            entity.UbicacionPro = dto.UbicacionPro;

            return entity;
        }
    }
}
