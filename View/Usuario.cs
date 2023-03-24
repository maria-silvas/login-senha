using System;
using System.Collections.Generic;

namespace View
{
    public class Usuario
    {
        public static void CriarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Criar usuário");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            try
            {
                Model.Usuario usuario = Controller.Usuario.CriarUsuario(
                    nome,
                    email,
                    senha
                );
                Console.WriteLine("Usuário criado com sucesso");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void AlterarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Alterar usuário");
            Console.WriteLine("---------------");
            Console.Write("Id: ");
            string id = Console.ReadLine();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            try
            {
                Model.Usuario usuario = Controller.Usuario.AlterarUsuario(
                    id,
                    nome,
                    email,
                    senha
                );
                Console.WriteLine("Usuário alterado com sucesso");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void ExcluirUsuario()
        {
            Console.Clear();
            Console.WriteLine("Excluir usuário");
            Console.WriteLine("---------------");
            Console.Write("Id: ");
            string id = Console.ReadLine();
            try
            {
                Controller.Usuario.ExcluirUsuario(id);
                Console.WriteLine("Usuário excluído com sucesso");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("Listar usuários");
            Console.WriteLine("---------------");
            List<Model.Usuario> usuarios = Controller.Usuario.ListarUsuarios();
            foreach (Model.Usuario usuario in usuarios)
            {
                Console.WriteLine(usuario);
            }
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}