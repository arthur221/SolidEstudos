using SolidEstudos.Interfaces;

namespace SolidEstudos.Services;

// Bastou criar essa implementação e o restante do sistema continuou igual.
// É um bom exemplo de OCP (estender sem modificar) e DIP (dependendo da interface).
public class WhatsAppNotificacaoService : INotificacaoService
{
    public Task EnviarConfirmacaoAsync(string destino, string mensagem)
    {
        Console.WriteLine($"[WHATSAPP] Para {destino}: {mensagem}");
        return Task.CompletedTask;
    }
}