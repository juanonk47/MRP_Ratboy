using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MRP_Ratboy.Models;

namespace MRP_Ratboy.services
{
    public class ControladorUsuariosBD
    {
        private BD_ArmadoPcEntities db = new BD_ArmadoPcEntities();
        
        public Usuarios ValidarCorreo(int id)
        {
            var registro = db.correoElectronico.Where(x => x.campoAutogenerado == id).FirstOrDefault();
            if (registro == null)
            {
                return null;
            }
            else
            {
                Usuarios usuarios = registro.Usuarios;
                usuarios.estatus = 1;
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                registro.estatus = false;
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return usuarios;
            }
        }
        public Usuarios UpdateUsuario (Usuarios usuarios)
        {
            var userDetail = db.Usuarios.Find(usuarios.idUsuario);
            if(userDetail == null)
            {
                return null;
            }
            else
            {
                userDetail.password = usuarios.password;
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return userDetail;
            }
        }
    }
}