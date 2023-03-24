using System;
using System.Collections.Generic;

namespace Controller
{
    public class Perfil
    {
        public static Model.Perfil CadastrarPerfil(
            string idUsuario,
            string tipo
        )
        {
            int idUsuarioInt = int.Parse(idUsuario);
            Model.Usuario usuario = Model.Usuario.BuscarUsuario(idUsuarioInt);

            if (!Enum.TryParse<Model.TipoPerfil>(tipo, out Model.TipoPerfil tipoPerfil) == false) {
                throw new Exception("-----Tipo de perfil inválido-----");
            }

            if (Model.Perfil.BuscarPerfilPorUsuario(usuario.Id) != null) {
                throw new Exception("-----Usuário já possui perfil-----");
            }

            return new Model.Perfil(usuario.Id, tipoPerfil);
        }

        public static void ExcluirPerfil(
            string id
        )
        {
            int idInt = int.Parse(id);
            Model.Perfil.ExcluirPerfil(idInt);
        }

        public static List<Model.Perfil> ListarPerfis()
        {
            return Model.Perfil.ListarPerfis();
        }
    }
}