using eAgenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloTarefa
{
    public class Item : EntidadeBase
    {
        private string descricao;
        private bool concluido;

        public Item(string descricao)
        {
            this.descricao = descricao;
            concluido = false;
        }

        public override string ToString()
        {
            string conclusao = "";
            if (concluido == true)
                conclusao = "Concluído";
            if (concluido == false)
                conclusao = "Não concluído";

                return "Descrição: " + descricao + "\n\t"
                + "Status de conclusão: " + conclusao + "\n\t";
        }

        public string ToStringLista()
        {
            string conclusao = "";
            if (concluido == true)
                conclusao = "Concluído";
            if (concluido == false)
                conclusao = "Não concluído";

            return "\n" + "Numero: " + numero 
            + "Descrição: " + descricao + "\n"
            + "Status de conclusão: " + conclusao + "\n";
        }
    }
}
