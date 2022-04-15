using eAgenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloContato
{
    public class Contato : EntidadeBase
    {
        private string nome;
        private string email;
        private string telefone;
        private string empresa;
        private string cargo;

        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.empresa = empresa;
            this.cargo = cargo;
        }

        public override string ToString()
        {
            return"\n" + "Numero: " + numero + "\n"
                + "Nome: " + nome + "\n"
                + "E-mail: " + email + "\n"
                + "Telefone: " + telefone + "\n"
                + "Empresa: " + empresa + "\n"
                + "Cargo: " + cargo;
         }
    }
}
