using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaBase, ICadastravel
    {
        public ControladorCaixa controladorCaixa = new ControladorCaixa();

        public TelaCaixa(ControladorCaixa controladorCaixa) : base("Registro das Caixas")
        {
            this.controladorCaixa = controladorCaixa;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo nova caixa...");

            bool conseguiuGravar = GravarCaixa(0);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa inserida com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir a caixa", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando caixas...");



            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            if (caixas.Length == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrada!", TipoMensagem.Atenção);
                return;
            }

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.WriteLine("Id:", caixas[i].idCaixa, " Cor:", caixas[i].corCaixa, " Etiqueta:", caixas[i].etiqueta);
            }
        }

        private bool GravarCaixa(int id)
        {
           
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            string resultadoValidacao = controladorCaixa.Registrar(id, cor, etiqueta);

            bool conseguiuGravar = true;

            if (resultadoValidacao != "CAIXA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }
    }
}
