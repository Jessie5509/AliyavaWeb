using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
    public class PCliente
    {
        public bool RegistrarCliente(DtoCliente dto)
        {
            bool msg;
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                { 
                    try
                    {
                        Cliente nuevoCliente = new Cliente();
                        nuevoCliente.Nombre = dto.Nombre;
                        nuevoCliente.Apellido = dto.Apellido;
                        nuevoCliente.Direccion = dto.Direccion;
                        nuevoCliente.email = dto.email;
                        nuevoCliente.NombreUsuario = dto.NombreUsuario;
                        nuevoCliente.Telefono = dto.Telefono;
                        nuevoCliente.contraseña = dto.contraseña;
                        nuevoCliente.latitud = dto.latitud;
                        nuevoCliente.longitud = dto.longitud;

                        context.Cliente.Add(nuevoCliente);
                        context.SaveChanges();

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        return msg = false;
                    }

                    return msg = true;
                }

            }
        }


        public DtoCliente getDataCli(string password, out bool existeDir)
        {
            DtoCliente dtoCli = new DtoCliente();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente clienteByPassword = context.Cliente.FirstOrDefault(f => f.contraseña == password);
                existeDir = context.Direcciones.Any(a => a.idCliente == clienteByPassword.idCliente);
                dtoCli = MCliente.MapToDto(clienteByPassword);
            }

                return dtoCli;
        }

        public List<DtoDirecciones> getDataDire(string password)
        {
            List<DtoDirecciones> colDtoDire = new List<DtoDirecciones>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente cli = context.Cliente.FirstOrDefault(f => f.contraseña == password);
                List<Direcciones> colDireDB = context.Direcciones.Where(w => w.idCliente == cli.idCliente).ToList();

                foreach (Direcciones dir in colDireDB)
                {
                    DtoDirecciones dto = MDirecciones.MapToDto(dir);
                    colDtoDire.Add(dto);
                }

        
            }

            return colDtoDire;
        }

        public void addDire(DtoDirecciones nuevaDireccion, string password )
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Direcciones dire = new Direcciones();
                        dire.Ciudad = nuevaDireccion.Ciudad;
                        dire.nombreDir = nuevaDireccion.nombreDir;
                        dire.Barrio = nuevaDireccion.Barrio;
                        dire.Apartamento = nuevaDireccion.Apartamento;
                        dire.Edificio = nuevaDireccion.Edificio;
                        dire.Numero = nuevaDireccion.Numero;
  
                        int idCli = context.Cliente.FirstOrDefault(f => f.contraseña == password).idCliente;

                        dire.idCliente = idCli;
             
                        context.Direcciones.Add(dire);
                        context.SaveChanges();

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                    }
                }

            }

        }

        public DtoDirecciones getNombreD(string password, string nombreD)
        {
            DtoDirecciones dtoDire = new DtoDirecciones();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente clienteByPassword = context.Cliente.FirstOrDefault(f => f.contraseña == password);
                dtoDire.nombreDir = nombreD;
                //dtoCli = MCliente.MapToDto(clienteByPassword);
            }

            return dtoDire;
        }

     
        public void eliminarDireccion(int id)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Direcciones Dire = context.Direcciones.FirstOrDefault(f => f.idDireccion == id);

                context.Direcciones.Remove(Dire);
                context.SaveChanges();
            }
        }
        public void UpdateCliente(DtoCliente dtoCliente)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Cliente updateCliente = context.Cliente.FirstOrDefault(f => f.contraseña == dtoCliente.contraseña);
                        updateCliente.Nombre = dtoCliente.Nombre;
                        updateCliente.Apellido = dtoCliente.Apellido;
                        updateCliente.NombreUsuario = dtoCliente.NombreUsuario;
                        updateCliente.Direccion = dtoCliente.Direccion;
                        updateCliente.Telefono = dtoCliente.Telefono;
                        updateCliente.email = dtoCliente.email;
                        updateCliente.contraseña = dtoCliente.contraseña;
                        updateCliente.latitud = dtoCliente.latitud;
                        updateCliente.longitud = dtoCliente.longitud;

                        context.SaveChanges();
                        scope.Complete();
                    }
                    catch(Exception ex)
                    {
                        scope.Dispose();
                    }
                    
                }
            }
        }

        public bool existeCliente(DtoCliente dto)
        {
            bool existe = false;

            using (AliyavaEntities context = new AliyavaEntities())
            {
                existe = context.Cliente.Any(a => a.NombreUsuario == dto.NombreUsuario && a.contraseña == dto.contraseña);

            }

                return existe;
        }


    }
}
