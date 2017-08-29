using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.ClassesBasicas;
using Biblioteca.Dados;

namespace Biblioteca.Negocio
{
    public class NegocioAgenda : Exception
    {
        private void validarDados(Agenda A)
        {
            if (A == null)
            {
                throw new Exception("Não é possível cadastrar um objeto nulo");
            }

        }


        public void InserirAgenda(Agenda A)
        {
            if (A == null)
            {
                throw new Exception("Não é possível cadastrar um objeto nulo");
            }

            DadosAgenda dl = new DadosAgenda();
            dl.InserirAgenda(A);
        }


        public void DeleteAgenda(Agenda A)
        {
            DadosAgenda dl = new DadosAgenda();
            dl.DeleteAgenda(A);
        }


        public List<Agenda> SelecionarAgenda()
        {
            DadosAgenda da = new DadosAgenda();
            return da.SelecionarAgenda();
        }


        public void AtualizarAgenda(Agenda A)
        {
            if (A == null)
            {
                throw new Exception("Não é possível alterar um objeto nulo");
            }
            DadosAgenda dl = new DadosAgenda();
            dl.AtualizarAgenda(A);
        }
    }
}
