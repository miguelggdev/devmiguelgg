using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicio> servicio;
 
    public RepositorioServicio()
        {
            servicio= new List<Servicio>()
            {
                new Servicio{id=1,origen=1,destino= 2,fecha= "6/5/2021",hora= "10:00",encomienda= 2},
                new Servicio{id=2,origen=3,destino= 4,fecha= "9/3/2021",hora= "14:00",encomienda= 3}
                 
            };
        }
 
        public IEnumerable<Servicio> GetAll()
        {
            return servicio;
        }
 
        public Servicio GetServicioWithId(int id){
            return servicio.SingleOrDefault(b => b.id == id);
        }

        public Servicio Update(Servicio newServicio)
        {

            var servicios= servicio.SingleOrDefault(b => b.id == newServicio.id);

            if(servicio != null){
                servicios.origen = newServicio.origen;
                servicios.destino = newServicio.destino;
                servicios.fecha = newServicio.fecha;
                servicios.hora = newServicio.hora;
                servicios.encomienda = newServicio.encomienda;
            }
        return servicios;
        }
        public Servicio Create(Servicio newServicio)
        {
           if(servicio.Count > 0){
           newServicio.id=servicio.Max(r => r.id) +1; 
            }else{
               newServicio.id = 1; 
            }
           servicio.Add(newServicio);
           return newServicio;
        }
        public void Delete(int id)
        {
        var service= servicio.SingleOrDefault(b => b.id == id);
        servicio.Remove(service);
        return;
        }

       

    }
}