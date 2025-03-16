using System.Text.Json.Serialization;

public class FibonacciSequenceResult{
    [JsonPropertyName("result")]
    public required ulong[] Result { get; set; }
}