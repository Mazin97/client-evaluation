using Flunt.Notifications;
using Flunt.Validations;

namespace ClientEvaluation.Domain.Commands.Contracts;

public interface ICommand
{
    void Validate();
}

