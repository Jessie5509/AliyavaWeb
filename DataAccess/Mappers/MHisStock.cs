using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MHisStock
    {
        public static DtoHistoricoStock MapToDto(HistoricoStock entity)
        {
            DtoHistoricoStock dto = new DtoHistoricoStock();
            dto.Ubicacion = entity.Ubicacion;
            dto.Cantidad = entity.Cantidad;
            dto.Motivo = entity.Motivo;
            dto.idEmpleado = entity.idEmpleado;
            dto.CantidadAddOBaja = entity.CantidadAddOBaja;

            return dto;
        }

        public static HistoricoStock MapToEntity(DtoHistoricoStock dto)
        {
            HistoricoStock entity = new HistoricoStock();
            entity.Ubicacion = dto.Ubicacion;
            entity.Cantidad = dto.Cantidad;
            entity.Motivo = dto.Motivo;
            entity.idEmpleado = dto.idEmpleado;
            entity.CantidadAddOBaja = dto.CantidadAddOBaja;

            return entity;
        }


    }
}
