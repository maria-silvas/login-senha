using Repository;
using System.Linq;
using System.Collections.Generic;

namespace Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            Database db = new Database();
            db.Usuarios.Add(this);
            db.SaveChanges();
        }

        public Usuario()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Email: {Email}, Senha: {Senha}";
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
            Usuario usuario = (Usuario) obj;
            return this.Id == usuario.Id;
        }

        public static Model.Usuario BuscarUsuario(
            int id
        )
        {
            Database db = new Database();
            try
            {
                Model.Usuario usuario = (from u in db.Usuarios
                                     where u.Id == id
                                     select u).First();
                return usuario;
            } catch
            {
                throw new System.Exception("-----Usuário não encontrado-----");
            }
            
        }

        public static Usuario AlterarUsuario(
            int id,
            string nome,
            string email,
            string senha
        )
        {
            try
            {
                Usuario usuario = BuscarUsuario(id);
                usuario.Email = email;
                usuario.Nome = nome;
                usuario.Senha = senha;
                Database db = new Database();
                db.Usuarios.Update(usuario);
                db.SaveChanges();

                return usuario;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void ExcluirUsuario(
            int id
        )
        {
            try
            {
                Model.Usuario usuario = BuscarUsuario(id);
                Database db = new Database();
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Model.Usuario> ListarUsuarios() {
            Database db = new Database();
            List<Model.Usuario> usuarios = (from u in db.Usuarios
                                        select u).ToList();
            return usuarios;
        }


        public static Model.Usuario BuscarPorEmail(string email) {
            try {
                Database db = new Database();
                Model.Usuario usuario = (from u in db.Usuarios
                                            where u.Email == email
                                            select u).First();
                return usuario;
            } catch {
                throw new System.Exception("Usuário não encontrado");
            }
        }
    }
}