﻿using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class MPedido
    {
        public static DtoPedido MapToDto(Pedido entity)
        {
            DtoPedido dto = new DtoPedido();
            dto.Numero = entity.Numero;
            dto.Usuario = entity.Usuario;
            dto.PrecioTotal = entity.PrecioTotal;
            dto.FechaIngreso = entity.FechaIngreso;
            dto.Estado = entity.Estado;
            dto.Direccion = entity.Direccion;
            dto.Urgente = entity.Urgente;

            return dto;
        }

        public static Pedido MapToEntity(DtoPedido dto)
        {
            Pedido entity = new Pedido();
            entity.Usuario = dto.Usuario;
            entity.Numero = dto.Numero;
            entity.PrecioTotal = dto.PrecioTotal;
            entity.FechaIngreso = dto.FechaIngreso;
            entity.Estado = dto.Estado;
            entity.Direccion = dto.Direccion;
            entity.Urgente = dto.Urgente;

            return entity;
        }
    }
}
