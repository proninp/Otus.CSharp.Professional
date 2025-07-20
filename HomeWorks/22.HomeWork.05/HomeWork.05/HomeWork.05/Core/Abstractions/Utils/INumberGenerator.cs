namespace HomeWork._05.Core.Abstractions.Utils;

/// <summary>
/// Интерфейс генератора случайных чисел
/// </summary>
public interface INumberGenerator
{
    /// <summary>
    /// Генерирует случайное число в указанном диапазоне
    /// </summary>
    /// <param name="min">Минимальное значение (включительно)</param>
    /// <param name="max">Максимальное значение (включительно)</param>
    /// <returns>Случайное целое число в диапазоне [min, max]</returns>
    int GetRandomNumber(int min, int max);
}