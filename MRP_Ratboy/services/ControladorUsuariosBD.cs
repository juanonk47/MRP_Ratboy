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
            var userDetails = db.Usuarios.Find(id);
            if (userDetails == null)
            {
                return null;
            }
            else
            {
                userDetails.estatus = 1;
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return userDetails;
            }
        }
        public Usuarios UpdateUsuario (Usuarios usuarios)
        {
            var userDetail = db.Usuarios.Find(usuarios.id);
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