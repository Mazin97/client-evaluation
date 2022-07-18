using ClientEvaluation.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ClientEvaluation.Domain.Commands;

public class CreateGradeCommand : Notifiable<Notification>, ICommand
{
    public CreateGradeCommand(Guid clientId, decimal score, string reason)
    {
        ClientId = clientId;
        Score = score;
        Reason = reason;
    }

    public Guid ClientId { get; set; }

    public decimal Score { get; set; }

    public string Reason { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<CreateGradeCommand>()
                .Requires()
                .IsNotNull(ClientId, "clientId", "O id do cliente é obrigatório")
                .IsBetween(0, 10, Score, "Score", "A pontuação deve estar entre 0 e 10")
                .IsNotNullOrEmpty(Reason, "Reason", "O motivo da avaliação é obrigatório")
        );
    }
}
