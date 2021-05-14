using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaAmigo : TelaBase, ICadastravel
    {
        public ControladorAmigo controladorAmigo = new ControladorAmigo();

        public TelaAmigo(ControladorAmigo controladorAmigo) : base("Registro do Amigo")
        {
            this.controladorAmigo = controladorAmigo;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo amigo...");

            bool conseguiuGravar = GravarAmigo(0);

            if (conseguiuGravar)
                ApresentarMensagem("Amiguinho inserido com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar inserir", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        private bool GravarAmigo(int id) {

            Console.WriteLine("Insira o nome do amigo:");
            string nomeAmigo = Console.ReadLine();

            Console.WriteLine("Insira o responsável do amigo:");
            string responsavel = Console.ReadLine();

            Console.WriteLine("insira o telefone do amigo:");
            string telefone = Console.ReadLine();

            Console.WriteLine("insira o endereço do amigo:");
            string endereco = Console.ReadLine();

            string resultadoValidacao = controladorAmigo.RegistrarAmigo(id, nomeAmigo, responsavel, telefone, endereco);

            bool conseguiuGravar = true;

            if (resultadoValidacao != "AMIGO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;

        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando amigos...");



            Amigo[] amigos = controladorAmigo.SelecionarTodosAmigos();

            if (amigos.Length == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrada!", TipoMensagem.Atenção);
                return;
            }

            foreach (Amigo amigo in amigos)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}", amigo.idAmigo, amigo.nome, amigo.telefone);
            }
           
        }

        


    }
}
