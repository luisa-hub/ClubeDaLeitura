using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Caixa
    {
        public int idCaixa;
        public string corCaixa;
        public string etiqueta;
        public Revista[] revistas; 

       

        public Caixa()
        {
            idCaixa = GeradorId.GerarIdCaixa();
            
        }

        public Caixa(Revista[] revistas) {

            
        }

        public Caixa(int idSelecionado)
        {
            idCaixa = idSelecionado;
        }
        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(corCaixa))
                resultadoValidacao += "O campo da cor e obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CAIXA_VALIDA";

            return resultadoValidacao;

        }
    }
}
