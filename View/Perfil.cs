using System;
using System.Collections.Generic;

namespace View
{
    public class Perfil
    {
        public static void CriarPerfil()
        {
            Console.Clear();
            Console.WriteLine("Criar perfil");
            Console.WriteLine("Digite o id do usuário");
            string idUsuario = Console.ReadLine();
            Console.WriteLine("Digite o tipo do perfil");
            string tipo = Console.ReadLine();
            try
            {
                Model.Perfil perfil = Controller.Perfil.CadastrarPerfil(idUsuario, tipo);
                Console.WriteLine("Perfil criado com sucesso");
                Console.WriteLine(perfil);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ExcluirPerfil()
        {
            Console.Clear();
            Console.WriteLine("Excluir perfil");
            Console.WriteLine("Digite o id do perfil");
            string id = Console.ReadLine();
            try
            {
                Controller.Perfil.ExcluirPerfil(id);
                Console.WriteLine("Perfil excluído com sucesso");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ListarPerfis()
        {
            Console.Clear();
            Console.WriteLine("Listar perfis");
            try
            {
                List<Model.Perfil> perfis = Controller.Perfil.ListarPerfis();
                foreach (Model.Perfil perfil in perfis)
                {
                    Console.WriteLine(perfil);
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}