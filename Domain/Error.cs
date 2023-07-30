using System.Text.Json;

namespace ServicesLifetime.Domain;

public class Error
{
    public string ErrorMessage { get; set; } = string.Empty;
    public string StatusCode { get; } = "500";

    public override string ToString() => JsonSerializer.Serialize(this);
    
}
