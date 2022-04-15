using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Compartilhado
{
    public class TelaBase
    {

        public virtual string MostrarOpcoesCrud()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar");
            Console.WriteLine("Ou digite V para voltar");

            String opcao = Console.ReadLine();

            return opcao;


        }
    }
}
