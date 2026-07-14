namespace SolidEstudos.Interfaces;

public interface ITarifaStrategy
{
    //aqui aplica o OCP que diz que novos tipos de tarifa podem ser adicionados sem modificar o codigo existente
    decimal CalcularTarifa(decimal valorBase, int noites);
}