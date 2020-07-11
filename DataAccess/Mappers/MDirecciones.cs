using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MDirecciones
    {
        public static DtoDirecciones MapToDto(Direcciones entity)
        {
            DtoDirecciones dto = new DtoDirecciones();
            dto.idCliente = entity.idCliente;
            dto.Numero = entity.Numero;
            dto.Ciudad = entity.Ciudad;
            dto.Barrio = entity.Barrio;
            dto.Apartamento = entity.Apartamento;
            dto.Edificio = entity.Edificio;
            dto.nombreDir = entity.nombreDir;
            dto.latitud = entity.latitud;
            dto.longitud = entity.longitud;
     
            return dto;
        }

        public static Direcciones MapToEntity(DtoDirecciones dto)
        {
            Direcciones entity = new Direcciones();
            entity.idCliente = dto.idCliente;
            entity.Numero = dto.Numero;
            entity.Ciudad = dto.Ciudad;
            entity.Barrio = dto.Barrio;
            entity.Apartamento = dto.Apartamento;
            entity.Edificio = dto.Edificio;
            entity.nombreDir = dto.nombreDir;
            entity.latitud = dto.latitud;
            entity.longitud = dto.longitud;

            return entity;
        }

    }
}
