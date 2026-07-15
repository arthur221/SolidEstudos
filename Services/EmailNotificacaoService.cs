using SolidEstudos.Interfaces;

namespace SolidEstudos.Services;

public class EmailNotificacaoService : INotificacaoService
{
    public Task EnviarConfirmacaoAsync(string destino, string mensagem)
    {
        Console.WriteLine($"[EMAIL] Para {destino}: {mensagem}");
        return Task.CompletedTask;
    }
}