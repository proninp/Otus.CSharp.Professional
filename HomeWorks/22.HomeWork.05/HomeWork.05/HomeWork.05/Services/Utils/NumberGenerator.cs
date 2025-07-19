using HomeWork._05.Core.Abstractions.Utils;

namespace HomeWork._05.Services.Utils;

public class NumberGenerator : INumberGenerator
{
    private readonly Random _random = new Random();
    
    public int GetRandomNumber(int min, int max) => 
        _random.Next(min, max + 1);
}