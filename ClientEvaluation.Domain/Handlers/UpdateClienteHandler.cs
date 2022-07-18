using ClientEvaluation.Domain.Commands;
using ClientEvaluation.Domain.Commands.Contracts;
using ClientEvaluation.Domain.Entites;
using ClientEvaluation.Domain.Handlers.Contracts;
using ClientEvaluation.Domain.Repositories;
using Flunt.Notifications;

namespace ClientEvaluation.Domain.Handlers;

public class UpdateClientHandler
    : Notifiable<Notification>,
    IHandler<UpdateClientCommand>
{
    private readonly IClientRepository _clientRepository;

    UpdateClientHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public ICommandResult Handle(UpdateClientCommand command)
    {
        command.Validate();

        if (!command.IsValid)
            return new GenericCommandResult(false, "Cliente inválido", command.Notifications);

        var client = _clientRepository.Get(command.Id);
        if (client == null)
            return new GenericCommandResult(false, "Cliente não encontrado", client);

        if (!IsValid)
            return new GenericCommandResult(false, "Falha ao criar o cliente", command.Notifications);

        _clientRepository.Save(client);
        return new GenericCommandResult(true, $"O cliente {client.CommercialName} foi criado com sucesso.", client);
    }
}