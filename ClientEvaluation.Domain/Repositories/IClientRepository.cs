using ClientEvaluation.Domain.Entites;

namespace ClientEvaluation.Domain.Repositories;

public interface IClientRepository
{
    Client Get(string CNPJ);

    Client Get(Guid id);

    public IEnumerable<Client> GetAll();

    void Save(Client client);
}
