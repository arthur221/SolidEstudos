using Microsoft.AspNetCore.Mvc;
using SolidEstudos.Factories;
using SolidEstudos.Services;

namespace SolidEstudos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly ReservaService _reservaService;
    private readonly TarifaStrategyFactory _tarifaFactory;

    public ReservasController(ReservaService reservaService, TarifaStrategyFactory tarifaFactory)
    {
        _reservaService = reservaService;
        _tarifaFactory = tarifaFactory;
    }

    public record CriarReservaRequest(
        string Hospede,
        string Email,
        DateTime CheckIn,
        DateTime CheckOut,
        decimal ValorDiaria,
        string TipoQuarto);

    [HttpPost]
    public async Task<IActionResult> CriarReserva(CriarReservaRequest request)
    {
        var tarifaStrategy = _tarifaFactory.Criar(request.TipoQuarto);

        var reserva = await _reservaService.CriarReservaAsync(
            request.Hospede,
            request.Email,
            request.CheckIn,
            request.CheckOut,
            request.ValorDiaria,
            tarifaStrategy);

        return Ok(reserva);
    }
}