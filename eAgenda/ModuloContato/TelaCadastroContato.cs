using eAgenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloContato
{
    public class TelaCadastroContato : TelaBase, ICadastravel
    {
        private Notificador notificador;
        private RepositorioContato repositorioContato;

        public TelaCadastroContato(RepositorioContato repositorioContato, Notificador notificador)
        {
            this.notificador = notificador;
            this.repositorioContato = repositorioContato;
        }

        public void EditarRegistro()
        {
            bool temContatosCadastradas = VisualizarRegistros();

            if (temContatosCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma contato cadastrada para editar", TipoMensagem.Atencao);
                return;
            }

            int numerocontato = ObterNumeroContato();

            Contato contatoAtualizado = ObterContato();

            repositorioContato.Editar(numerocontato, contatoAtualizado);

            notificador.ApresentarMensagem("Contato editado com sucesso", TipoMensagem.Sucesso);
        }

        private int ObterNumeroContato()
        {
            int numeroContato;
            bool numeroContatoEncontrado;

            do
            {
                Console.Write("Digite o número do contato que deseja selecionar: ");
                numeroContato = Convert.ToInt32(Console.ReadLine());

                numeroContatoEncontrado = repositorioContato.VerificarNumeroRegistroExiste(numeroContato);

                if (numeroContatoEncontrado == false)
                    notificador.ApresentarMensagem("Número do contato não encontrado, digite novamente.", TipoMensagem.Atencao);

            } while (numeroContatoEncontrado == false);
            return numeroContato;
        }

        public void ExcluirRegistro()
        {
            bool temContatosCadastrados = VisualizarRegistros();

            if (temContatosCadastrados == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma contato cadastrado para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroContato();

            repositorioContato.Excluir(numeroContato);

            notificador.ApresentarMensagem("Contato excluído com sucesso", TipoMensagem.Sucesso);
        }

        public void InserirRegistro()
        {
            Contato novoContato = ObterContato();
            repositorioContato.Inserir(novoContato);
            notificador.ApresentarMensagem("Contato cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        private Contato ObterContato()
        {
            Console.WriteLine();
            Console.Write("Digite o nome do contato: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o nome da empresa: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o cargo: ");
            string cargo  = Console.ReadLine();

            Contato contato = new Contato(nome, email, telefone, empresa, cargo);
            return contato;
        }

        public bool VisualizarRegistros()
        {
            List<EntidadeBase> contatos = repositorioContato.SelecionarTodos();

            if (contatos.Count == 0)
            {
                notificador.ApresentarMensagem("Não há nenhum contato disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contato contato in contatos)
                Console.WriteLine(contato.ToString());

            Console.ReadLine();

            return true;
        }
    }
}
