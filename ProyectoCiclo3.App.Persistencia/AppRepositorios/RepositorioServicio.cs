using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        // List<Servicio> servicio;
    private readonly AppContext _appContext = new AppContext(); 
    
    public IEnumerable<Servicio> GetAll()
        {
           return _appContext.Servicio.Include(u => u.origen)
                       .Include(u => u.destino).
                       Include(e => e.encomienda);
        }


        public Servicio GetServicioWithId(int id){
            return _appContext.Servicio.Find(id);
        }

        public Servicio Create(int origen, int destino, string fecha, string hora, int encomienda)
        {
            var newServicio = new Servicio();
            newServicio.destino = _appContext.Usuario.Find(destino);
            newServicio.origen = _appContext.Usuario.Find(origen);          
            newServicio.encomienda = _appContext.Encomienda.Find(encomienda);
            newServicio.fecha = fecha;
            newServicio.hora = hora;
            var addServicio = _appContext.Servicio.Add(newServicio);
            _appContext.SaveChanges();
            return addServicio.Entity;

        }

        public Servicio Update(Servicio newServicio){
        var service = _appContext.Servicio.Find(newServicio.id);
            if(service != null){
                service.origen = newServicio.origen;
                service.destino = newServicio.destino;
                service.fecha = newServicio.fecha;
                service.hora = newServicio.hora;
                service.encomienda = newServicio.encomienda;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
        return service;
        }
        public void Delete(int id) 
        {
        var service = _appContext.Servicio.Find(id);
        if (service == null)
            return;
        _appContext.Servicio.Remove(service);
        _appContext.SaveChanges();
        }

       

    }
}