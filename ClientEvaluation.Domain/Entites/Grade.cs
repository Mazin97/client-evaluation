using Flunt.Validations;

namespace ClientEvaluation.Domain.Entites;

public class Grade : Entity
{
    public Grade(Guid clientId, int score, string reason)
    {
        AddNotifications(
            new Contract<Grade>()
                .Requires()
                .IsNotNull(clientId, "clientId", "O id do cliente é obrigatório")
                .IsBetween(0, 10, score, "Score", "A pontuação deve estar entre 0 e 10")
                .IsNotNullOrEmpty(reason, "Reason", "O motivo da avaliação é obrigatório")
        );

        ClientId = clientId;
        Score = score;
        Reason = reason;
    }

    public Guid ClientId { get; private set; }

    public int Score { get; private set; }

    public string Reason { get; private set; }
}

