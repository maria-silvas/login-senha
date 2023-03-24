using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public enum TipoPerfil
    {
        Admin,
        User
    }
    
    public class Perfil
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public TipoPerfil Tipo { get; set; }

        public Perfil(int usuarioId, TipoPerfil tipo)
        {
            this.UsuarioId = usuarioId;
            this.Tipo = tipo;
            Database db = new Database();
            db.Perfis.Add(this);
            db.SaveChanges();

            this.Usuario = Usuario.BuscarUsuario(usuarioId);
        }

        public Perfil()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Usuario: {Usuario.Nome}, Tipo: {Tipo}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) {
                return false;
            }
            if (obj == this) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            Perfil perfil = (Perfil) obj;
            return this.Id == perfil.Id;
        }

        public static Perfil BuscarPerfil(int id) {
            Database db = new Database();
            try
            {
                Perfil perfil = (from p in db.Perfis
                                 join u in db.Usuarios on p.UsuarioId equals u.Id
                                 where p.Id == id
                                 select p).First();
                return perfil;
            }
            catch (Exception)
            {
                throw new Exception("-----Perfil não encontrado-----");
            }
        }

        public static Perfil BuscarPerfilPorUsuario(int UsuarioId) {
            Database db = new Database();
            try
            {
                Perfil perfil = (from p in db.Perfis
                                 where p.UsuarioId == UsuarioId
                                 select p).First();
                return perfil;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ExcluirPerfil(int id) {
            Database db = new Database();

            Perfil perfil = BuscarPerfil(id);
            db.Perfis.Remove(perfil);
            db.SaveChanges();
        }

        public static List<Perfil> ListarPerfis()
        {
            Database db = new Database();
            return db.Perfis.Include("Usuario").ToList();            
        }

    }
}