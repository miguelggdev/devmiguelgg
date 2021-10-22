using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        // List<Encomienda> encomienda;
        private readonly AppContext _appContext = new AppContext();  

        public IEnumerable<Encomienda> GetAll()
        {
           return _appContext.Encomienda;
        }

        public Encomienda GetEncomiendaWithId(int id){
            return _appContext.Encomienda.Find(id);
        }

        public Encomienda Create(Encomienda newEncomienda)
        {
            var addEncomienda = _appContext.Encomienda.Add(newEncomienda);
            _appContext.SaveChanges();
            return addEncomienda.Entity;
        }
                
        public Encomienda Update(Encomienda newEncomienda){
        var encomiend = _appContext.Encomienda.Find(newEncomienda.id);
            if(encomiend != null){
                encomiend.descripcion = newEncomienda.descripcion;
                encomiend.peso = newEncomienda.peso;
                encomiend.tipo = newEncomienda.tipo;
                encomiend.presentacion = newEncomienda.presentacion;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
        return encomiend;
        }
        public void Delete(int id) 
        {
        var encomiend = _appContext.Encomienda.Find(id);
        if (encomiend == null)
            return;
        _appContext.Encomienda.Remove(encomiend);
        _appContext.SaveChanges();
        }
                      
    }
}