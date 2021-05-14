using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorRevista : ControladorBase
    {
        public ControladorCaixa controladorCaixa = new ControladorCaixa();
        public string Registrar(int id, int idCaixaSelecionada, string nome, string tipoColecao, string ano, string numeroEdicao)
        {
            Revista revista = null;

            int posicao;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }

            revista.anoRevista = ano;
            revista.caixaRevista = controladorCaixa.SelecionarCaixaPorId(idCaixaSelecionada);
            revista.nome = nome;
            revista.numeroEdicao = numeroEdicao;
            revista.tipoColecao = tipoColecao;



            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "REVISTA_VALIDA")
                registros[posicao] = revista;
            return resultadoValidacao;
        }

        public Revista[] SelecionarTodasRevistass()
        {
            Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }
    }
}
