using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaBase
    {
        private string titulo;

        public string Titulo { get { return titulo; } }

        public TelaBase(string tit)
        {
            titulo = tit;
        }

       

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo registro");
            Console.WriteLine("Digite 2 para visualizar registros");
           
            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected void ApresentarMensagem(string mensagem, TipoMensagem tm)
        {
            switch (tm)
            {
                case TipoMensagem.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case TipoMensagem.Atenção:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case TipoMensagem.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        protected void ConfigurarTela(string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }
    }
}
