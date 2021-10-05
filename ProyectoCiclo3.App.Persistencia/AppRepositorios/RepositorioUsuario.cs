using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;

namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> usuario;
 
    public RepositorioUsuario()
        {
            usuario= new List<Usuario>()
            {
                new Usuario{id=1,nombre="Mario",apellidos= "Sánchez",direccion= "Carrera 27",telefono= "8945412121"},
                new Usuario{id=2,nombre="Camila",apellidos= "Rodriguez",direccion= "Calle 96",telefono= "895656562"},
                new Usuario{id=3,nombre="Maria Carolina",apellidos= "Perez",direccion= "Avenida Sur con 14",telefono= "12145454"} 
            };
        }
                
 
        public IEnumerable<Usuario> GetAll()
        {
            return usuario;
        }
        
 
        public Usuario GetUsuarioWithId(int id){
            return usuario.SingleOrDefault(b => b.id == id);
        }

        public Usuario Create(Usuario newUsuario)
        {
           if(usuario.Count > 0){
           newUsuario.id=usuario.Max(r => r.id) +1; 
            }else{
               newUsuario.id = 1; 
            }
           usuario.Add(newUsuario);
           return newUsuario;
        }


                
        public Usuario Update(Usuario newUsuario){

            var usuarios= usuario.SingleOrDefault(b => b.id == newUsuario.id);

            if(usuarios != null){
                usuarios.nombre = newUsuario.nombre;
                usuarios.apellidos = newUsuario.apellidos;
                usuarios.direccion = newUsuario.direccion;
                usuarios.telefono = newUsuario.telefono;
                }
        return usuarios;
        }

        public void Delete(int id)
        {
        var user= usuario.SingleOrDefault(b => b.id == id);
        usuario.Remove(user);
        return;
        }

    }
}

