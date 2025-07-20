using HomeWork._05.Core.Abstractions.Utils;

namespace HomeWork._05.Services.Utils;

/// <summary>
/// Реализация генератора случайных чисел
/// </summary>
public sealed class NumberGenerator : INumberGenerator
{
    private readonly Random _random = new Random();
    
    /// <summary>
    /// Генерирует случайное число в указанном диапазоне
    /// </summary>
    /// <param name="min">Минимальное значение (включительно)</param>
    /// <param name="max">Максимальное значение (включительно)</param>
    /// <returns>Случайное целое число в диапазоне [min, max]</returns>
    public int GetRandomNumber(int min, int max) => 
        _random.Next(min, max + 1);
}