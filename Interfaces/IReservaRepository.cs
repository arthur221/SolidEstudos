using SolidEstudos.Models;

namespace SolidEstudos.Interfaces;

public interface IReservaRepository
{
    // aqui eu apliquei a inversao de dependencia, ou seja, a camada de negócio não conhece detalhes do banco de dados
    Task SalvarAsync(Reserva reserva);
    Task<Reserva?> ObterPorIdAsync(int id);
}