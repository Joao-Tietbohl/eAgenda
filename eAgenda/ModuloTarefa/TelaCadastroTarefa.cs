
using eAgenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase, ICadastravel
    {
        private Notificador notificador;
        private RepositorioTarefa repositorioTarefa;

        public TelaCadastroTarefa(RepositorioTarefa repositorioTarefa, Notificador notificador)
        {
            this.notificador = notificador;
            this.repositorioTarefa = repositorioTarefa;
        }

        public override string MostrarOpcoesCrud()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Visualizar");
            Console.WriteLine("5 - Editar status de item");
            Console.WriteLine("Ou digite V para voltar");

            String opcao = Console.ReadLine();

            return opcao;

        }

        public void EditarStatusItem()
        {
            bool temTarefasCadastradas = VisualizarRegistros();

            if (temTarefasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma tarefa cadastrada para editar", TipoMensagem.Atencao);
                return;
            }
            int numeroTarefa = ObterNumeroTarefa();
            
            repositorioTarefa.AlterarStatusItem(numeroTarefa);

            
        }

        public void InserirRegistro()
        {

            Tarefa novaTarefa = ObterTarefa();
            repositorioTarefa.Inserir(novaTarefa);
            notificador.ApresentarMensagem("Tarefa cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

       

        public void EditarRegistro()
        {
            bool temTarefasCadastradas = VisualizarRegistros();

            if (temTarefasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma tarefa cadastrada para editar", TipoMensagem.Atencao);
                return;
            }
                int numeroTarefa = ObterNumeroTarefa();

                Tarefa tarefaAtualizada = ObterTarefa();

                repositorioTarefa.Editar(numeroTarefa, tarefaAtualizada);

                notificador.ApresentarMensagem("Tarefa editada com sucesso", TipoMensagem.Sucesso);
            
        }

        public bool VisualizarRegistros()
        {

            List<EntidadeBase> tarefas = repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
            {
                notificador.ApresentarMensagem("Não há nenhum tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Tarefa tarefa in tarefas)
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;
        }

    

        public void ExcluirRegistro()
        {
            bool temTarefasCadastradas = VisualizarRegistros();

            if (temTarefasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma tarefa cadastrada para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroTarefa();

            repositorioTarefa.Excluir(numeroTarefa);

            notificador.ApresentarMensagem("Tarefa excluída com sucesso", TipoMensagem.Sucesso);
        }


        private Tarefa ObterTarefa()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Qual a prioridade da tarefa?");
            Console.WriteLine("1- Alta  2- Media  3- Baixa");
            int intPrioridade = Int32.Parse(Console.ReadLine());
            Prioridade prioridade = new Prioridade();
            if (intPrioridade == 1)
                prioridade = Prioridade.alta;
            if (intPrioridade == 2)
                prioridade = Prioridade.media;
            if (intPrioridade == 3)
                prioridade = Prioridade.baixa;

            List<Item> listaItens = new List<Item>();
            string descricao = "";
            int cont = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Digite a descrição de um item para a conclusão da tarefa, ou digite C para continuar");
                Console.WriteLine("Quantidade de itens atual: " + cont);
                descricao = Console.ReadLine();

                while (cont == 0 && (descricao == "C" || descricao == "c"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Tarefa deve ter ao menos 1 item. Digite a descrição do item: ");
                    descricao = Console.ReadLine();
                }
                if (descricao == "C" || descricao == "c")
                    break;

                Item item = new Item(descricao);
                listaItens.Add(item);
                cont++;

            } while (descricao != "C" || descricao != "c");

            Console.WriteLine();
            Console.WriteLine("Digite a data de criação da tarefa: ");
            DateTime dataCriacao = DateTime.Parse(Console.ReadLine());

            Tarefa tarefa = new Tarefa(titulo, prioridade, listaItens, dataCriacao);
            
            return tarefa;
        }

        private int ObterNumeroTarefa()
        {
            int numeroTarefa;
            bool numeroTarefaEncontrada;

            do
            {
                Console.Write("Digite o número da tarefa que deseja selecionar: ");
                numeroTarefa = Convert.ToInt32(Console.ReadLine());

                numeroTarefaEncontrada = repositorioTarefa.VerificarNumeroRegistroExiste(numeroTarefa);

                if (numeroTarefaEncontrada == false)
                    notificador.ApresentarMensagem("Número da tarefa não encontrado, digite novamente.", TipoMensagem.Atencao);

            } while (numeroTarefaEncontrada == false);
            return numeroTarefa;
        }

        
        
    }
}
