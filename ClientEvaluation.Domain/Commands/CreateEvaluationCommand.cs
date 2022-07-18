using ClientEvaluation.Domain.Commands.Contracts;
using ClientEvaluation.Domain.Entites;
using Flunt.Notifications;
using Flunt.Validations;

namespace ClientEvaluation.Domain.Commands;

public class CreateEvaluationCommand : Notifiable<Notification>, ICommand
{
    public CreateEvaluationCommand(List<Grade> grades)
    {
        Grades = grades;
    }

    public List<Grade> Grades { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<CreateEvaluationCommand>()
                .Requires()
                .IsNotNull(Grades, "Grades", "É obrigatório haver notas na avaliação")
                .IsGreaterThan(0, Grades.Count, "Grades", "É obrigatório haver pelo menos uma nota na avaliação")
        );
    }
}
