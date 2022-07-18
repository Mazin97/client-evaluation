using ClientEvaluation.Domain.Commands.Contracts;

namespace ClientEvaluation.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}