using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Emprestimo
    {
        public int idEmprestimo;
        public DateTime dataAbertura;
        public DateTime dataDevolucao;
        public Amigo amigoEmprestimo;
        public Revista revistaEmprestimo;

        public Emprestimo()
        {
            idEmprestimo = GeradorId.GerarIdEmprestimo();

        }

        public Emprestimo(int idSelecionado)
        {
            idEmprestimo = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (amigoEmprestimo.possuiRevista)
                resultadoValidacao += "O amigo já possui revista \n";

            if (revistaEmprestimo.emprestada)
                resultadoValidacao += "A revista já foi emprestada \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;

        }
    }
}
