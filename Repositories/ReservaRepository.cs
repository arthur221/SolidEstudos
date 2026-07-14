using SolidEstudos.Interfaces;
using SolidEstudos.Models;

namespace SolidEstudos.Repositories;

// vou criar uma lista em memoria para ficar mais simples
// O resto do sistema NUNCA vai conhecer essa classe diretamente — só a interface (DIP).
// o resto do sistema nao vai conhecer essa classe so a interface isso é o principio da inversão de dependência (DIP)
public class ReservaRepository : IReservaRepository
{
    private readonly List<Reserva> _reservas = new();

    public Task SalvarAsync(Reserva reserva)
    {
        reserva.Id = _reservas.Count + 1;
        _reservas.Add(reserva);
        Console.WriteLine($"[DB] Reserva {reserva.Id} salva.");
        return Task.CompletedTask;
    }
    
    public Task<Reserva> ObterPorIdAsync(int id)
    => Task.FromResult(_reservas.FirstOrDefault(r => r.Id == id));
}