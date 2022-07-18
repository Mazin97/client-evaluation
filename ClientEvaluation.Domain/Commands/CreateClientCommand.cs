using ClientEvaluation.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ClientEvaluation.Domain.Commands;
public class CreateClientCommand : Notifiable<Notification>, ICommand
{
    public CreateClientCommand() { }

    public CreateClientCommand(string commercialName, string responsibleName, string cNPJ)
    {
        CommercialName = commercialName;
        ResponsibleName = responsibleName;
        CNPJ = cNPJ;
    }

    public string CommercialName { get; set; }

    public string ResponsibleName { get; set; }

    public string CNPJ { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<CreateClientCommand>()
                .Requires()
                .IsNotNullOrEmpty(CommercialName, "commercialName", "A razão social é obrigatória")
                .IsGreaterOrEqualsThan(CommercialName, 3, "commercialName", "A razão social deve conter ao menos 3 caracteres")
                .IsLowerThan(CommercialName, 200, "commercialName", "A razão social deve conter até 200 caracteres")
                .IsNotNullOrEmpty(ResponsibleName, "responsibleName", "O nome do responsável é obrigatória")
                .IsGreaterOrEqualsThan(ResponsibleName, 3, "responsibleName", "O nome do responsável deve conter ao menos 3 caracteres")
                .IsLowerThan(ResponsibleName, 200, "responsibleName", "O nome do responsável deve conter até 200 caracteres")
        );
    }
}
