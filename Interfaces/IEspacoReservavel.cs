namespace SolidEstudos.Interfaces;

public interface IEspacoReservavel
{
    // aplica o principio da segragação de interfaces que diz que uma classe não deve ser forçada a implementar métodos que não utiliza
    int Id { get; }
    string Descricao { get; }
}