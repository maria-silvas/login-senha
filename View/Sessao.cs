using System;
using System.Collections.Generic;

namespace View
{
    public class Sessao
    {
        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("Login");
            Console.WriteLine("Digite o email");
            string email = Console.ReadLine();
            Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();
            try
            {
                Model.Sessao sessao = Controller.Sessao.Login(email, senha);
                Console.WriteLine("Login efetuado com sucesso");
                Console.WriteLine(sessao);
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Logoff()
        {
            Console.Clear();
            Console.WriteLine("Logoff");
            Console.WriteLine("Digite o id da sessão");
            string id = Console.ReadLine();
            try
            {
                Controller.Sessao.Logoff(id);
                Console.WriteLine("Logoff efetuado com sucesso");
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ListarSessoes()
        {
            Console.Clear();
            Console.WriteLine("Listar sessões");
            try
            {
                List<Model.Sessao> sessoes = Controller.Sessao.ListarSessoes();
                foreach (Model.Sessao sessao in sessoes)
                {
                    Console.WriteLine(sessao);
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}