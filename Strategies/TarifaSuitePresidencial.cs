using SolidEstudos.Interfaces;

namespace SolidEstudos.Strategies;

// isso é do OCP: adicionamos um novo tipo de tarifa criando uma nova classe, sem alterar o código existente.
public class TarifaSuitePresidencial : ITarifaStrategy
{
    public decimal CalcularTarifa(decimal valorBase, int noites) => valorBase * noites * 3m;
}