using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeDaLeitura.ConsoleApp.Controladores;
namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaBase, ICadastravel
    {
        private TelaCaixa telaCaixa;
        public ControladorRevista controladorRevista = new ControladorRevista();

        public TelaRevista(ControladorRevista controladorRevista, TelaCaixa telaCaixa) : base("Registro das Revistas")
        {
            this.controladorRevista = controladorRevista;
            this.telaCaixa = telaCaixa;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo nova revista...");

            bool conseguiuGravar = GravarRevista(0);

            if (conseguiuGravar)
                ApresentarMensagem("Revista inserida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir a revista", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        private bool GravarRevista(int id)
        {

            telaCaixa.VisualizarRegistros();

            Console.WriteLine("Digite o numero da caixa que deseja inserir a revista:");
            int idCaixaSelecionada = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o nome da revista:");
            string nome = Console.ReadLine();

            Console.Write("Digite o tipo de coleção da revista: ");
            string tipoColecao = Console.ReadLine();

            Console.WriteLine("Digite o ano da coleção:");
            string ano = Console.ReadLine();

            Console.WriteLine("Digite o numero da edição:");
            string numeroEdicao = Console.ReadLine();

            string resultadoValidacao = controladorRevista.Registrar(id, idCaixaSelecionada, nome, tipoColecao, ano, numeroEdicao);

            bool conseguiuGravar = true;

            if (resultadoValidacao != "REVISTA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        public void VisualizarRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
