using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeDaLeitura.ConsoleApp.Controladores;
namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaEmprestimo : TelaBase
    {

        public ControladorEmprestimo controladorEmprestimo;
        public TelaAmigo telaAmigo;
        public TelaRevista telaRevista;

        public TelaEmprestimo(ControladorEmprestimo controladorEmprestimo, TelaAmigo telaAmigo, TelaRevista telaRevista) : base("Registro dos Empréstimos")
        {
            this.controladorEmprestimo = controladorEmprestimo;
            this.telaAmigo = telaAmigo;
            this.telaRevista = telaRevista;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Realizando novo empréstimo...");

            bool conseguiuGravar = GravarEmprestimo(0);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa inserida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao realizar o empréstimo", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void DevolverEmpréstimo() {
            
        
        }

        private bool GravarEmprestimo(int id)
        {

            telaAmigo.VisualizarRegistros();

            Console.Write("Digite o Id do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            telaRevista.VisualizarRegistros();
            Console.Write("Digite o Id da revista:");
            int  idRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data da devolução ");
            DateTime dataADevolucao = Convert.ToDateTime(Console.ReadLine());

            string resultadoValidacao = controladorEmprestimo.Registrar(id, idAmigo, idRevista, dataADevolucao);

            bool conseguiuGravar = true;

            if (resultadoValidacao != "EMPRESTIMO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        internal void VisualizarEmprestimosFechados()
        {
            throw new NotImplementedException();
        }

        internal void VisualizarEmprestimosAbertos()
        {
            throw new NotImplementedException();
        }
    }
}
