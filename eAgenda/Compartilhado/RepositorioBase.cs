using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Compartilhado
{
    public class RepositorioBase
    {
        protected readonly List<EntidadeBase> registros;
        protected int contadorNumero;

        public RepositorioBase()
        {
            registros = new List<EntidadeBase>();
        }

        public virtual void Inserir(EntidadeBase entidade)
        {

            entidade.numero = ++contadorNumero;

            registros.Add(entidade);
  
        }

        public void Editar(int numeroSelecioando, EntidadeBase entidade)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i].numero == numeroSelecioando)
                {
                    entidade.numero = numeroSelecioando;
                    registros[i] = entidade;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i].numero == numeroSelecionado)
                {
                    registros[i] = null;
                    break;
                }
            }
        }

        public virtual EntidadeBase SelecionarRegistro(int numeroRegistro)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i] != null && numeroRegistro == registros[i].numero)
                    return registros[i];
            }

            return null;
        }

        public List<EntidadeBase> SelecionarTodos()
        {

            List<EntidadeBase> registrosInseridos = new List<EntidadeBase>();


            foreach (EntidadeBase item in registros)
            {
               registrosInseridos.Add(item);
            }

            return registrosInseridos;
        }

        public bool VerificarNumeroRegistroExiste(int numeroRegistro)
        {
            bool numeroRegistroExiste = false;

            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i] != null && registros[i].numero == numeroRegistro)
                {
                    numeroRegistroExiste = true;
                    break;
                }
            }

            return numeroRegistroExiste;
        }

        protected int ObterQtdRegistros()
        {
            int numeroRegistros = 0;

            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i] != null)
                    numeroRegistros++;
            }

            return numeroRegistros;
        }

    }
}
