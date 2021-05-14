using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
     public class ControladorAmigo : ControladorBase
    {
        public string RegistrarAmigo(int id, string nome, string responsavel, string telefone, string endereco)
        {
            Amigo amiguinho = null;

            int posicao;

            if (id == 0)
            {
                amiguinho = new Amigo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amigo(id));
                amiguinho = (Amigo)registros[posicao];
            }

            amiguinho.endereco = endereco;
            amiguinho.responsavel = responsavel;
            amiguinho.nome = nome;
            amiguinho.telefone = telefone;

            string resultadoValidacao = amiguinho.Validar();

            if (resultadoValidacao == "AMIGO_VALIDO")
                registros[posicao] = amiguinho;

            return resultadoValidacao;
        }

        

       

        public Amigo[] SelecionarTodosAmigos()
        {
            Amigo[] amigoAux = new Amigo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amigoAux, amigoAux.Length);

            return amigoAux;
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            return (Amigo)SelecionarRegistroPorId(new Amigo(id));
        }
    }
}
