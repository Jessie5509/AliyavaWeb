using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MReparto
    {
        public static DtoReparto MapToDto(Reparto entity)
        {
            DtoReparto dto = new DtoReparto();
            dto.Chofer = entity.Chofer;
            dto.MatriculaVehiculo = entity.MatriculaVehiculo;
            dto.Estado = entity.Estado;
            dto.FechaSalida = entity.FechaSalida;
     
            return dto;
        }

        public static Reparto MapToEntity(DtoReparto dto)
        {
            Reparto entity = new Reparto();
            entity.Chofer = dto.Chofer;
            entity.MatriculaVehiculo = dto.MatriculaVehiculo;
            entity.Estado = dto.Estado;
            entity.FechaSalida = dto.FechaSalida;
            

            return entity;
        }
    }
}
