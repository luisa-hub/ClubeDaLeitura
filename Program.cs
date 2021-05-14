using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Telas;

namespace ClubeDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ControladorRevista controladorRevista = new ControladorRevista();

            ControladorAmigo controladorAmigo = new ControladorAmigo();

            ControladorCaixa controladorCaixa = new ControladorCaixa();

            TelaCaixa telaCaixa = new TelaCaixa(controladorCaixa);

            TelaRevista telaRevista = new TelaRevista(controladorRevista, telaCaixa);

            TelaAmigo telaAmigo = new TelaAmigo(controladorAmigo);

           
           
            TelaPrincipal telaPrincipal = new TelaPrincipal(controladorRevista,
           telaCaixa, controladorAmigo,  controladorCaixa);

            while (true)
            {
                TelaBase telaSelecionada = telaPrincipal.ObterOpcao();
                
                if (telaSelecionada == null)
                    break;

                Console.Clear();

                Console.WriteLine(telaSelecionada.Titulo); Console.WriteLine();

                string opcao = telaSelecionada.ObterOpcao();

                if (telaSelecionada is ICadastravel)
                {
                    ICadastravel tela = (ICadastravel)telaSelecionada;

                    if (opcao == "1")
                        tela.InserirNovoRegistro();

                    else if (opcao == "2")
                    {
                        tela.VisualizarRegistros();
                        Console.ReadLine();
                    }
                }

                else if (telaSelecionada is TelaEmprestimo) {

                    TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaSelecionada;

                    if (opcao == "1")
                            telaEmprestimo.InserirNovoRegistro();

                    if (opcao == "2")
                        telaEmprestimo.DevolverEmpréstimo();

                    if (opcao == "3")
                        telaEmprestimo.VisualizarEmprestimosFechados();

                    else if (opcao == "4")
                        telaEmprestimo.VisualizarEmprestimosAbertos();

                
                }


                Console.Clear();
            }
        }
    }
}
