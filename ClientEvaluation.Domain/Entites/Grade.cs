using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEvaluation.Domain.Entites;

public class Grade : Entity
{
    public Grade(Guid clientId, int score, string reason)
    {
        AddNotifications(
            new Contract<Grade>()
                .Requires()
                .IsNotNull(clientId, "clientId", "O id do cliente é obrigatório")
        );

        ClientId = clientId;
        Score = score;
        Reason = reason;
    }

    public Guid ClientId { get; private set; }

    public int Score { get; private set; }

    public string Reason { get; private set; }
}

