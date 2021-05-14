using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorCaixa : ControladorBase
    {

       

        public string Registrar(int id, string cor, string etiqueta)
        {
           Caixa caixa = null;

            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }

            caixa.corCaixa = cor;
            caixa.etiqueta = etiqueta;
                      
            

            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CAIXA_VALIDA")
                registros[posicao] = caixa;
            return resultadoValidacao;
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixaAux = new Caixa[QtdRegistrosCadastrados()];

        Array.Copy(SelecionarTodosRegistros(), caixaAux, caixaAux.Length);

            return caixaAux;
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }
    }
}
