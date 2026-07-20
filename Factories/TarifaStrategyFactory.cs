using SolidEstudos.Interfaces;
using SolidEstudos.Strategies;

namespace SolidEstudos.Factories;

// Centralizei aqui a escolha da estratégia de tarifa
// Assim essa lógica não fica espalhada pelo sistema e,
// se surgir um novo tipo de quarto, basta adicionar o caso aqui
public class TarifaStrategyFactory
{
    public ITarifaStrategy Criar(string tipoQuarto)
    {
        return tipoQuarto.ToLower() switch
        {
            "luxo" => new TarifaQuartoLuxo(),
            "suitepresidencial" => new TarifaSuitePresidencial(),
            _ => new TarifaQuartoStandard()
        };
    }
}