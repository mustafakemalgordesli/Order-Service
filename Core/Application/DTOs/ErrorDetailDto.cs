using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.DTOs;

public class ErrorDetailDto
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; } = false;
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
