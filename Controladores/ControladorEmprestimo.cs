using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        public ControladorAmigo controladorAmigo;
        public ControladorRevista controladorRevista;

        public ControladorEmprestimo(ControladorAmigo controladorAmigo, ControladorRevista controladorRevista)
        {
            this.controladorAmigo = controladorAmigo;
            this.controladorRevista = controladorRevista;


        }
        public string Registrar(int id, int idAmigo, int idRevista, DateTime dataDevolucao)
        {
            Emprestimo emprestimo = null;

            int posicao;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.amigoEmprestimo = controladorAmigo.SelecionarAmigoPorId(idAmigo);
            emprestimo.revistaEmprestimo = controladorRevista.SelecionarRevistaPorId(idRevista);
            emprestimo.dataAbertura = DateTime.Now;
            emprestimo.dataDevolucao = dataDevolucao;



            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
            {
                registros[posicao] = emprestimo;
                controladorAmigo.SelecionarAmigoPorId(idAmigo).RegistrarEmprestimo(emprestimo);
                controladorRevista.SelecionarRevistaPorId(idRevista).RegistrarEmprestimo(emprestimo);
                emprestimo.amigoEmprestimo.possuiRevista = true;

            }

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
