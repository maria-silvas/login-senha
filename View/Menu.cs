using System;

namespace View
{
    public class Menu
    {
        public static void MostrarMenu()
        {
            System.Console.WriteLine("(1) - Cadastrar usuário");
            System.Console.WriteLine("(2) - Alterar usuário");
            System.Console.WriteLine("(3) - Excluir usuário");
            System.Console.WriteLine("(4) - Listar usuários");
            System.Console.WriteLine("(5) - Cadastrar perfil");
            System.Console.WriteLine("(6) - Excluir perfil");
            System.Console.WriteLine("(7) - Listar perfis");
            System.Console.WriteLine("(8) - Cadastrar sessão");
            System.Console.WriteLine("(9)- Excluir sessão");
            System.Console.WriteLine("(10) - Listar sessões");
            System.Console.WriteLine("(0) - Sair");
            System.Console.WriteLine("Digite a opção desejada: ");
        }

        public static void ExibirMenu() {
            int opcao = -1;
            do {
                MostrarMenu();
                opcao = int.Parse(Console.ReadLine());
                switch (opcao) {
                    case 1:
                        View.Usuario.CriarUsuario();
                        break;
                    case 2:
                        View.Usuario.AlterarUsuario();
                        break;
                    case 3:
                        View.Usuario.ExcluirUsuario();
                        break;
                    case 4:
                        View.Usuario.ListarUsuarios();
                        break;
                    case 5:
                        View.Perfil.CriarPerfil();
                        break;
                    case 6:
                        View.Perfil.ExcluirPerfil();
                        break;
                    case 7:
                        View.Perfil.ListarPerfis();
                        break;
                    case 8:
                        View.Sessao.Login();
                        break;
                    case 9:
                        View.Sessao.Logoff();
                        break;
                    case 10:
                        View.Sessao.ListarSessoes();
                        break;
                    case 0:
                        System.Console.WriteLine("*******Obrigado por utilizar nosso programa *******!");
                        break;
                    default:
                        System.Console.WriteLine("Opção inválida!!!!!!");
                        break;
                }
            } while (opcao != 0);
        }
    }
}