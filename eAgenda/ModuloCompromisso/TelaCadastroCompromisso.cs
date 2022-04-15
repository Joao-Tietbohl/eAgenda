using eAgenda.Compartilhado;
using eAgenda.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase, ICadastravel
    {

        private Notificador notificador;
        private RepositorioCompromisso repositorioCompromisso;
        private RepositorioContato repositorioContato;
        private TelaCadastroContato telaCadastroContato;

        public TelaCadastroCompromisso(RepositorioCompromisso repositorioCompromisso, RepositorioContato repositorioContato, Notificador notificador)
        {
            this.notificador = notificador;
            this.repositorioCompromisso = repositorioCompromisso;
            this.repositorioContato = repositorioContato;
        }

        public void EditarRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void InserirRegistro()
        {
            Compromisso novoCompromisso = ObterCompromisso();
            repositorioCompromisso.Inserir(novoCompromisso);
            notificador.ApresentarMensagem("Compromisso cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        private Compromisso ObterCompromisso()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o assunto: ");
            string assunto = Console.ReadLine();

            Console.WriteLine("Digite o local: ");
            string local = Console.ReadLine();

            Console.WriteLine("Digite a data do compromisso: ");
            DateTime horarioInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o horario do compromisso: (hh,mm)");
            string horario = Console.ReadLine();
            string[] horarioArray = horario.Split( "," );
           
            horarioInicio.AddHours(Int32.Parse(horarioArray[0]));
            horarioInicio.AddMinutes(Int32.Parse(horarioArray[1]));

            DateTime horarioTermino = new DateTime();
            horarioTermino = horarioInicio;

            Console.WriteLine("Qual a duração do compromisso?  (hh,mm)");
            string duracao = Console.ReadLine();
            string[] duracaoArray = duracao.Split(",");
            
            horarioTermino.AddHours(Int32.Parse(duracaoArray[0]));
            horarioTermino.AddMinutes(Int32.Parse(duracaoArray[1]));

            telaCadastroContato.VisualizarRegistros();
            Console.WriteLine("Digite o numero de ID do contato, ou digite 0 se não houver contato para o compromisso: ");
            int numero = Int32.Parse(Console.ReadLine());

            Contato contato = repositorioContato.SelecionarRegistro(numero);

            Compromisso compromisso = new Compromisso(assunto, local, horarioInicio, horarioTermino, contato);

            return compromisso;
             
        }

        private int ObterNumeroCompromisso()
        {

            int numeroCompromisso;
            bool numeroCompromissoEncontrado;

            do
            {
                Console.Write("Digite o número do compromisso que deseja selecionar: ");
                numeroCompromisso = Convert.ToInt32(Console.ReadLine());

                numeroCompromissoEncontrado = repositorioCompromisso.VerificarNumeroRegistroExiste(numeroCompromisso);

                if (numeroCompromissoEncontrado == false)
                    notificador.ApresentarMensagem("Número do compromisso não encontrado, digite novamente.", TipoMensagem.Atencao);

            } while (numeroCompromissoEncontrado == false);
            return numeroCompromisso;
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
