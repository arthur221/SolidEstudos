namespace SolidEstudos.Interfaces;

public interface INotificacaoService
{
    // aqui o serviço de reserva deve depender desta interface, e não de uma implementação específica. 
    // Isso é o princípio de inversão de dependência.
    Task EnviarConfirmacaoAsync(string destino, string mensagem);
}