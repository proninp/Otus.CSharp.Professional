namespace HomeWork._06;

public class SerializationExample
{
    private int I1 { get; set; }

    private int I2 { get; set; }

    private double D1 { get; set; }

    private decimal Dec4 { get; set; }

    public char Ch1 { get; set; }

    public string? S1 { get; set; }

    public static SerializationExample Get() => new() { I1 = 1, I2 = 2, D1 = 3.0, Dec4 = 4M, Ch1 = 'C', S1 = "FooBar" };

    public override string ToString()
    {
        return $"{{ I1 = {I1}, I2 = {I2}, D1 = {D1}, Dec4 = {Dec4}, Ch1 = {Ch1}, S1 = {S1} }}";
    }
}