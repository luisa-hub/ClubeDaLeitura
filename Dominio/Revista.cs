using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Revista
    {
        public int idRevista;
        public string nome;
        public string tipoColecao;
        public string numeroEdicao;
        public string anoRevista;
        public Caixa caixaRevista;

        public Emprestimo[] historicoEmprestimos = new Emprestimo[100];
        public bool emprestada;

        public Revista() {

            idRevista = GeradorId.GerarIdRevista();
            emprestada = false;
        }

        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {

           // historicoEmprestimos[ObterPosicaoVaga()] = emprestimo;
            emprestada = true;
        }
        public Revista(int idSelecionado)
        {
            idRevista = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo nome é obrigatório \n";

            if (string.IsNullOrEmpty(tipoColecao))
                resultadoValidacao += "Tipo de coleção é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDA";

            return resultadoValidacao;

        }
    }
}
