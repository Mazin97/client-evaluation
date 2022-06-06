using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEvaluation.Domain.Entites;
public class Evaluation : Entity
{
    public Evaluation()
    {
        CreatedAt = DateTime.Now;
        Grades = new List<Grade>();
    }

    public DateTime CreatedAt { get; private set; }

    public IList<Grade> Grades { get; private set; }

    public void AddGrade(Grade grade)
    {
        if (grade.IsValid)
            Grades.Add(grade);
    }
}
