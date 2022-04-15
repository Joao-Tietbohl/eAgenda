using eAgenda.ModuloCompromisso;
using eAgenda.ModuloContato;
using eAgenda.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Compartilhado
{
    public class MenuPrincipal
    {
        TelaCadastroTarefa telaCadastroTarefa;
        RepositorioTarefa repositorioTarefa;
        TelaCadastroContato telaCadastroContato;
        RepositorioContato repositorioContato;
        TelaCadastroCompromisso telaCadastroCompromisso;
        RepositorioCompromisso repositorioCompromisso;
        

        public MenuPrincipal(Notificador notificador)
        {
            
            repositorioTarefa = new RepositorioTarefa();
            repositorioContato = new RepositorioContato();
            repositorioCompromisso = new RepositorioCompromisso();
            
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa, notificador);
            telaCadastroContato = new TelaCadastroContato(repositorioContato, notificador);
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, repositorioContato, notificador);
        }

        public void MostrarOpcoesCrud()
        {
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar");
        }
        
        public TelaBase MostrarOpcoesTelas()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("1 - Tela Tarefas");
            Console.WriteLine("2 - Tela Contatos");
            Console.WriteLine("3 - Tela Compromissos");

            int opcao = Int32.Parse(Console.ReadLine());

            TelaBase tela = new TelaBase();

            switch (opcao)
            {
                case 1:
                    tela = telaCadastroTarefa;
                    break;

                case 2:
                    tela = telaCadastroContato;
                    break;

                case 3:
                    tela = telaCadastroCompromisso;
                    break;
                    
            }
            return tela;
        }
    }
}
 