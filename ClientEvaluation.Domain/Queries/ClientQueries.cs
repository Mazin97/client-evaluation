using ClientEvaluation.Domain.Entites;
using System.Linq.Expressions;

namespace ClientEvaluation.Domain.Queries;

public static class ClientQueries
{
    public static Expression<Func<Client, bool>> GetByDocuemnt(string document)
    {
        return x => x.CNPJ.ToLower() == document.ToLower();
    }
}
