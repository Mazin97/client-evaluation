using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEvaluation.Domain.Commands;

public class GenericCommandResult
{
    public GenericCommandResult(Exception ex)
    {
        Success = false;
        Message = ex.Message;
    }

    public GenericCommandResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; private set; }

    public string Message { get; private set; }

    public object Data { get; private set; }
}
