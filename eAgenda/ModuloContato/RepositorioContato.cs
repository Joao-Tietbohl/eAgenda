using eAgenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloContato
{
    public class RepositorioContato : RepositorioBase
    {

        public override Contato SelecionarRegistro(int numeroRegistro)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i] != null && numeroRegistro == registros[i].numero)
                    return (Contato)registros[i];
            }

            return null;
        }
    }
}
