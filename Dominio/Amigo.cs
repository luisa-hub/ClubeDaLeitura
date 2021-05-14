using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
namespace ClubeDaLeitura.ConsoleApp
{
    public class Amigo
    {
        public int idAmigo;
        public string endereco;
        public string telefone;
        public string nome;
        public string responsavel;

        public Emprestimo[] historicoEmprestimos = new Emprestimo[100];
        public bool possuiRevista;

        

        public Amigo()
        {
            idAmigo  = GeradorId.GerarIdAmigo();
            possuiRevista = false;
        }


        
        public Amigo(int idSelecionado)
        {
            idAmigo = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "O campo nome é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "AMIGO_VALIDO";

            return resultadoValidacao;

        }

        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {
            
            possuiRevista = true;
        }
    }
}
