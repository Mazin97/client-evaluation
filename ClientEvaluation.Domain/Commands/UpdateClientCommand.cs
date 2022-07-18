using ClientEvaluation.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ClientEvaluation.Domain.Commands;

public class UpdateClientCommand : Notifiable<Notification>, ICommand
{
    public UpdateClientCommand() { }

    public UpdateClientCommand(Guid id, string commercialName, string responsibleName)
    {
        Id = id;
        CommercialName = commercialName;
        ResponsibleName = responsibleName;
    }

    public Guid Id { get; set; }

    public string CommercialName { get; set; }

    public string ResponsibleName { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<CreateClientCommand>()
                .Requires()
                .IsNotNull(Id, "Id", "O Id do cliente é obrigatório")
                .IsGreaterOrEqualsThan(CommercialName, 3, "commercialName", "A razão social deve conter ao menos 3 caracteres")
                .IsLowerThan(CommercialName, 200, "commercialName", "A razão social deve conter até 200 caracteres")
                .IsGreaterOrEqualsThan(ResponsibleName, 3, "responsibleName", "O nome do responsável deve conter ao menos 3 caracteres")
                .IsLowerThan(ResponsibleName, 200, "responsibleName", "O nome do responsável deve conter até 200 caracteres")
        );
    }
}
