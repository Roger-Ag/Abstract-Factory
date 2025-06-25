using System;

namespace NotificacaoFactory {
    // Produto Abstrato
    public interface INotificacao {
        void Enviar(string mensagem);
    }

    // Produto Concreto: E-mail
    public class EmailNotificacao : INotificacao {
        public void Enviar(string mensagem) {
            Console.WriteLine($" Enviando E-MAIL: {mensagem}");
        }
    }

    // Produto Concreto: SMS
    public class SmsNotificacao : INotificacao {
        public void Enviar(string mensagem) {
            Console.WriteLine($" Enviando SMS: {mensagem}");
        }
    }

    // Fábrica Abstrata
    public interface INotificacaoFactory {
        INotificacao CriarNotificacao();
    }

    // Fábrica Concreta: E-mail
    public class EmailFactory : INotificacaoFactory {
        public INotificacao CriarNotificacao() {
            return new EmailNotificacao();
        }
    }

    // Fábrica Concreta: SMS
    public class SmsFactory : INotificacaoFactory {
        public INotificacao CriarNotificacao() {
            return new SmsNotificacao();
        }
    }

    // Classe Cliente
    public class Notificador {
        private readonly INotificacao _notificacao;

        public Notificador(INotificacaoFactory factory) {
            _notificacao = factory.CriarNotificacao();
        }

        public void EnviarMensagem(string mensagem) {
            _notificacao.Enviar(mensagem);
        }
    }

    // Programa principal
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Escolha o tipo de notificação:");
            Console.WriteLine("1 - E-mail");
            Console.WriteLine("2 - SMS");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            INotificacaoFactory factory;

            if (opcao == "1")
                factory = new EmailFactory();
            else
                factory = new SmsFactory();

            var notificador = new Notificador(factory);
            notificador.EnviarMensagem("Olá, esta é uma mensagem de teste!");

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();

        }
    }
}
