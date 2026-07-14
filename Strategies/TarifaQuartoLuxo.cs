using SolidEstudos.Interfaces;

namespace SolidEstudos.Strategies;

public class TarifaQuartoLuxo : ITarifaStrategy
{
    public decimal CalcularTarifa(decimal valorBase, int noites) => valorBase * noites * 1.5m;
}