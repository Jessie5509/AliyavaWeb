using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MStock
    {
        public static DtoStock MapToDto(Stock entity)
        {
            DtoStock dto = new DtoStock();
            dto.Ubicacion = entity.Ubicacion;
            dto.Cantidad = entity.Cantidad;
            dto.Motivo = entity.Motivo;
      
            return dto;
        }

        public static Stock MapToEntity(DtoStock dto)
        {
            Stock entity = new Stock();
            entity.Ubicacion = dto.Ubicacion;
            entity.Cantidad = dto.Cantidad;
            entity.Motivo = dto.Motivo;
   
            return entity;
        }

    }
}
