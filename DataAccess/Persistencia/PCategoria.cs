using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PCategoria
    {

        public void RegistrarCategoria(DtoCategoria dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Categoria Cat = new Categoria();
                Cat.Nombre = dto.Nombre;
                Cat.idProducto = dto.idProducto;


                context.Categoria.Add(Cat);
                context.SaveChanges();

            }
        }


        public List<DtoCategoria> GetCategoria()
        {
            List<DtoCategoria> coldtoCat = new List<DtoCategoria>();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Categoria> colCategoria = context.Categoria.Select(s => s).ToList();

                foreach (Categoria cat in colCategoria)
                {
                    DtoCategoria dto = MCategoria.MapToDto(cat);
                    coldtoCat.Add(dto);
                }
            }
            return coldtoCat;
        }


        public void RemoveCategoria(DtoCategoria dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {

                Categoria cat = MCategoria.MapToEntity(dto);

                context.Categoria.Remove(cat);
                context.SaveChanges();

            }


        }



    }
}
