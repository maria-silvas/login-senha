using System;
using System.Collections.Generic;

namespace Controller
{
    public class Sessao
    {
        public static Model.Sessao Login(
            string email,
            string password
        )
        {
            try {
                Model.Usuario usuario = Usuario.BuscarPorEmail(email);

                if (usuario.Senha != password) {
                    throw new Exception("Senha inválida");
                }

                return new Model.Sessao(usuario.Id);
            } catch
            {
                throw new Exception("Login inválido");
            }
        }

        public static void Logoff(
            string id
        )
        {
            int idInt = int.Parse(id);
            Model.Sessao.AlterarSessao(idInt, new DateTime());
        }

        public static List<Model.Sessao> ListarSessoes()
        {
            return Model.Sessao.ListarSessoes();
        }
    }
}