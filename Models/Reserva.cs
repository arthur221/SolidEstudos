namespace SolidEstudos.Models;

public class Reserva
{
    public int Id { get; set; }
    public string Hospede { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal ValorTotal { get; set; }
}