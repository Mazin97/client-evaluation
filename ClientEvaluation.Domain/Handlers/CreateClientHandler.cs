using ClientEvaluation.Domain.Commands;
using ClientEvaluation.Domain.Commands.Contracts;
using ClientEvaluation.Domain.Entites;
using ClientEvaluation.Domain.Handlers.Contracts;
using ClientEvaluation.Domain.Repositories;
using Flunt.Notifications;

namespace ClientEvaluation.Domain.Handlers;

public class CreateClientHandler
    : Notifiable<Notification>,
    IHandler<CreateClientCommand>
{
    private readonly IClientRepository _clientRepository;

    CreateClientHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public ICommandResult Handle(CreateClientCommand command)
    {
        command.Validate();

        if (!command.IsValid)
            return new GenericCommandResult(false, "Cliente inválido", command.Notifications);

        var clientWithSameDocument = _clientRepository.Get(command.CNPJ);
        if (clientWithSameDocument != null)
            return new GenericCommandResult(false, "CNPJ existente", command.CNPJ);

        var client = new Client(command.CommercialName, command.ResponsibleName, command.CNPJ);
        AddNotifications(client.Notifications);

        if (!IsValid)
            return new GenericCommandResult(false, "Falha ao criar o cliente", command.Notifications);

        _clientRepository.Save(client);
        return new GenericCommandResult(true, $"O cliente {client.CommercialName} foi criado com sucesso.", client);
    }
}