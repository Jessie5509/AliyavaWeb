using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MHisEstado
    {
        public static DtoHistoricoEstado MapToDto(Historico_de_Cambio_de_estados entity)
        {
            DtoHistoricoEstado dto = new DtoHistoricoEstado();
            dto.Accion = entity.Accion;
            dto.Estados = entity.Estados;
            dto.FechaCambio = entity.FechaCambio;
            dto.Funcionario = entity.Funcionario;
            dto.numPedido = entity.numPedido;

            return dto;
        }

        public static Historico_de_Cambio_de_estados MapToEntity(DtoHistoricoEstado dto)
        {
            Historico_de_Cambio_de_estados entity = new Historico_de_Cambio_de_estados();
            entity.Accion = dto.Accion;
            entity.Estados = dto.Estados;
            entity.FechaCambio = dto.FechaCambio;
            entity.Funcionario = dto.Funcionario;
            entity.numPedido = dto.numPedido;

            return entity;
        }
    }
}
