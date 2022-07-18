using ClientEvaluation.Domain.Entites;
using ClientEvaluation.Domain.Repositories;
using ClientEvaluation.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClientEvaluation.Infra.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DataContext _context;

    public ClientRepository(DataContext context)
    {
        _context = context;
    }

    public Client Get(string CNPJ)
    {
        return _context.Clients.FirstOrDefault(x => x.CNPJ == CNPJ);
    }

    public Client Get(Guid id)
    {
        return _context.Clients.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Client> GetAll()
    {
        return _context
            .Clients
            .AsNoTracking()
            .OrderBy(x => x.CommercialName);
    }

    public void Save(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }
}
