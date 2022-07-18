using ClientEvaluation.Domain.Commands;
using ClientEvaluation.Domain.Entites;
using ClientEvaluation.Domain.Handlers;
using ClientEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientEvaluation.Api.Controllers;

[ApiController]
[Authorize]
[Route("v1/client")]
public class ClientController : ControllerBase
{
    [HttpGet("")]
    public IEnumerable<Client> Get(
        [FromServices] IClientRepository repository
    )
    {
        return repository.GetAll();
    }

    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateClientCommand command,
        [FromServices] CreateClientHandler handler
    )
    {
        return (GenericCommandResult)handler.Handle(command);
    }
}
