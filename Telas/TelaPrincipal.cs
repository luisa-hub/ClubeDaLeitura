using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeDaLeitura.ConsoleApp.Controladores;
namespace ClubeDaLeitura.ConsoleApp.Telas
{
    class TelaPrincipal
    {
        
        private readonly ControladorRevista controladorRevista;
        private readonly TelaRevista telaRevista;
        private readonly ControladorAmigo controladorAmigo;
        private readonly TelaAmigo telaAmigo;
        private readonly ControladorCaixa controladorCaixa;
        private readonly TelaCaixa telaCaixa;
        private readonly ControladorEmprestimo controladorEmprestimo;
        private readonly TelaEmprestimo telaEmprestimo;




        public TelaPrincipal(ControladorRevista controladorRevista,
           TelaCaixa telaCaixa, ControladorAmigo controladorAmigo, ControladorCaixa controladorCaixa, ControladorEmprestimo controladorEmprestimo, TelaEmprestimo telaEmprestimo)
        {
            this.controladorRevista = controladorRevista;
            this.controladorCaixa = controladorCaixa;
            this.telaCaixa = telaCaixa;
            this.controladorAmigo = controladorAmigo;
            this.controladorEmprestimo = controladorEmprestimo;
            this.telaEmprestimo = telaEmprestimo;

        }

        public TelaBase ObterOpcao()
        {
            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para o Cadastro de Amigos");
                Console.WriteLine("Digite 2 para o Cadastro de Caixas");
                Console.WriteLine("Digite 3 para o Cadastro de Revistas");
                Console.WriteLine("Digite 4 para realizar empréstimos");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = new TelaAmigo(controladorAmigo);

                else if (opcao == "2")
                    telaSelecionada = new TelaCaixa(controladorCaixa);

                else if (opcao.Equals("3"))
                    telaSelecionada = new TelaRevista(controladorRevista, telaCaixa);

                else if (opcao.Equals("4"))
                    telaSelecionada = new TelaEmprestimo(controladorEmprestimo, telaAmigo, telaRevista);

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else
                return false;
        }
    }
}
