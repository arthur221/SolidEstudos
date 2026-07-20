using SolidEstudos.Exceptions;
using SolidEstudos.Interfaces;
using SolidEstudos.Models;

namespace SolidEstudos.Services;

public class ReservaService
{
    // O serviço depende apenas das interfaces, então tanto o repositório
    // quanto a forma de notificação podem ser trocados sem alterar essa classe.
    private readonly IReservaRepository _repository;
    private readonly INotificacaoService _notificacaoService;

    public ReservaService(IReservaRepository repository, INotificacaoService notificacaoService)
    {
        _repository = repository;
        _notificacaoService = notificacaoService;
    }

    public async Task<Reserva> CriarReservaAsync(
        string hospede, string email,
        DateTime checkIn, DateTime checkOut,
        decimal valorDiaria, ITarifaStrategy tarifaStrategy)
    {

        if (checkOut <= checkIn)
        throw new ReservaException("A data de check-out deve ser depois do check-in.");

        var reserva = new Reserva
        {
            Hospede = hospede,
            Email = email,
            CheckIn = checkIn,
            CheckOut = checkOut,

        };

        // O cálculo do valor fica por conta da estratégia escolhida,
        // assim posso criar novas regras de tarifa sem mexer nesse serviço
        var noites = reserva.CalcularNoites();
        reserva.ValorTotal = tarifaStrategy.CalcularTarifa(valorDiaria, noites);

        await _repository.SalvarAsync(reserva);

        await _notificacaoService.EnviarConfirmacaoAsync(
            email, $"Reserva confirmada! Total: R${reserva.ValorTotal}");

        return reserva;
    }
}