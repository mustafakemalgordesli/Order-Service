using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Wrappers;

public class ServiceResponse<T>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T? Value { get; set; }
    public bool Success { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Message { get; set; } 

    public ServiceResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    public ServiceResponse(T value)
    {
        Success = true;
        Value = value;
    }
    public ServiceResponse(T value, string message)
    {
        Success = true;
        Value = value;
        Message = message;
    }
    public ServiceResponse(bool success)
    {
        Success = success;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

public class ServiceResponse
{
    public bool Success { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Message { get; set; }

    public ServiceResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    public ServiceResponse(bool success)
    {
        Success = success;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
