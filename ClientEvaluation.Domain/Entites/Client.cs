using Flunt.Validations;

namespace ClientEvaluation.Domain.Entites;

public class Client : Entity
{
    public Client(string commercialName, string responsibleName, string CNPJ)
    {
        AddNotifications(
            new Contract<Client>()
                .Requires()
                .IsNotNullOrEmpty(commercialName, "commercialName", "A razão social é obrigatória")
                .IsGreaterOrEqualsThan(commercialName, 3, "commercialName", "A razão social deve conter ao menos 3 caracteres")
                .IsLowerThan(commercialName, 200, "commercialName", "A razão social deve conter até 200 caracteres")
                .IsNotNullOrEmpty(responsibleName, "responsibleName", "O nome do responsável é obrigatória")
                .IsGreaterOrEqualsThan(responsibleName, 3, "responsibleName", "O nome do responsável deve conter ao menos 3 caracteres")
                .IsLowerThan(responsibleName, 200, "responsibleName", "O nome do responsável deve conter até 200 caracteres")
        );

        if (!string.IsNullOrEmpty(CNPJ) && CNPJ.Length != 14)
            AddNotification("CNPJ", "o CNPJ é inválido");

        CommercialName = commercialName;
        ResponsibleName = responsibleName;
        this.CNPJ = CNPJ;
        RegistratedAt = DateTime.Now;
    }

    public string CommercialName { get; private set; }

    public string ResponsibleName { get; private set; }

    public string CNPJ { get; private set; }

    public DateTime RegistratedAt { get; private set; }

    public int? Rate { get; private set; }
}