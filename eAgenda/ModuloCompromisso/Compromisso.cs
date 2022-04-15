using eAgenda.Compartilhado;
using eAgenda.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {
        private string assunto;
        private string local;
        private DateTime horarioInicio;
        private DateTime horarioTermino;
        private Contato contato;

        public Compromisso(string assunto, string local, DateTime horarioInicio, DateTime horarioTermino, Contato contato)
        {
            this.assunto = assunto;
            this.local = local;
            this.horarioInicio = horarioInicio;
            this.horarioTermino = horarioTermino;
            this.contato = contato;
        }
    }
}
