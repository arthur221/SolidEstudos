using SolidEstudos.Interfaces;

namespace SolidEstudos.Strategies;

public class TarifaQuartoStandard : ITarifaStrategy
{
    public decimal CalcularTarifa(decimal valorBase, int noites) => valorBase * noites;
}