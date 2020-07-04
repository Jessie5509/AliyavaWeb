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
                Cat.idCategoria = dto.idCategoria;
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


        public void RemoveCategoria(int id)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {

                Categoria cat = context.Categoria.FirstOrDefault(f => f.idCategoria == id);
                context.Categoria.Remove(cat);
                context.SaveChanges();

            }


        }

        public void ModificarCategoria(DtoCategoria DtoCat)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Categoria updatecat = context.Categoria.FirstOrDefault(f => f.idCategoria == DtoCat.idCategoria);
                updatecat.Nombre = DtoCat.Nombre;
                updatecat.idProducto = DtoCat.idProducto;
                

                context.SaveChanges();
            }
        }


        public DtoCategoria GetCategoriaM(int id)
        {
            DtoCategoria dto = new DtoCategoria();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Categoria cat = context.Categoria.FirstOrDefault(f => f.idCategoria == id);

                dto = MCategoria.MapToDto(cat);
            }
            return dto;
        }


        public List<DtoCategoria> getCat(string familia)
        {
            List<DtoCategoria> colCatego = new List<DtoCategoria>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Categoria> colCat = context.Categoria.Where(w=> w.Nombre == familia).ToList();

                foreach (Categoria item in colCat)
                {
                    DtoCategoria dto = MCategoria.MapToDto(item);
                    colCatego.Add(dto);
                }
            }

            return colCatego;
        }



    }
}
