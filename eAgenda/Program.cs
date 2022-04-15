using eAgenda.Compartilhado;
using eAgenda.ModuloCompromisso;
using eAgenda.ModuloContato;
using eAgenda.ModuloTarefa;
using System;

namespace eAgenda
{
    internal class Program
    {
        static Notificador notificador = new Notificador();
        static MenuPrincipal menuPrincipal = new MenuPrincipal(notificador);

        static void Main(string[] args)
        {
            while (true)
            {
                TelaBase telaSelecionada = menuPrincipal.MostrarOpcoesTelas();

                string opcaoSelecionada = telaSelecionada.MostrarOpcoesCrud();

                if (telaSelecionada is null)
                    return;

                if (telaSelecionada is TelaCadastroTarefa)
                {
                    GerenciarCadastroBasico(telaSelecionada, opcaoSelecionada);
                    GerenciarCadastroTarefa(telaSelecionada, opcaoSelecionada);
                }
                if (telaSelecionada is TelaCadastroContato)
                {
                    GerenciarCadastroBasico(telaSelecionada, opcaoSelecionada);
                }
                if (telaSelecionada is TelaCadastroCompromisso)
                    GerenciarCadastroBasico(telaSelecionada, opcaoSelecionada);
            }
        }

        private static void GerenciarCadastroTarefa(TelaBase telaSelecionada, string opcaoSelecionada)
        {
            TelaCadastroTarefa telaCadastroTarefa = telaSelecionada as TelaCadastroTarefa;

            if (opcaoSelecionada == "5")
                telaCadastroTarefa.EditarStatusItem();
        }

        private static void GerenciarCadastroBasico(TelaBase telaSelecionada, string opcaoSelecionada)
        {
           ICadastravel telaCadastroBasico = telaSelecionada as ICadastravel;

            if(opcaoSelecionada == "1")
               telaCadastroBasico.InserirRegistro();

            if (opcaoSelecionada == "2")
                telaCadastroBasico.EditarRegistro();

            if (opcaoSelecionada == "3")
                telaCadastroBasico.ExcluirRegistro();

            if (opcaoSelecionada == "4")
                telaCadastroBasico.VisualizarRegistros();
        }
    }
}
