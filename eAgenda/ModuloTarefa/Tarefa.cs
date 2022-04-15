using eAgenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloTarefa
{

    public class Tarefa : EntidadeBase
    {
        private string titulo;
        private Prioridade prioridade;
        private List<Item> listaItens;
        private DateTime dataCriacao;
        private DateTime dataConclusao;
        private int percentualConclusao;
        private bool concluida;

        

       // public List<Item> ListaItens1 { get => listaItens; set => listaItens = value; }

        public List<Item> ListaItens { get
            {
                return listaItens;
            } }

        public Tarefa(string titulo, Prioridade prioridade, List<Item> listaItens, DateTime dataCriacao)
        {
            this.titulo = titulo;
            this.prioridade = prioridade;
            this.listaItens = listaItens;
            this.dataCriacao = dataCriacao;
            this.percentualConclusao = 0;
            this.concluida = false;
        }

        public override string ToString()
        {
            string stringListaItens = "";
            for (int i = 0; i < listaItens.Count; i++)
                stringListaItens += listaItens[i].ToString();

            return "\n" + "Numero: " + numero + "\n" 
                + "Título: " + titulo + "\n"
                + "Prioridade: " + prioridade + "\n"
                + "Lista de Itens: \n\t" + stringListaItens + "\n"
                + "Data de Crição: " + dataCriacao.ToShortDateString() + "\n"
                + "Percentual de conlusão: " + percentualConclusao;
        }

        public string ToStringListaItens()
        {
            return listaItens.ToString();
        }


    }


    public enum Prioridade
    {
        alta, media, baixa
    }
}
