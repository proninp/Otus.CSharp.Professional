using HomeWork._05.Core.Abstractions.Game;

namespace HomeWork._05.Services.Game;

/// <summary>
/// Сервис для вычисления игровых параметров
/// </summary>
public sealed class GameCalculator : IGameCalculator
{
    /// <summary>
    /// Вычислить оптимальное максимальное количество попыток для угадывания числа
    /// </summary>
    /// <param name="minNumber">Минимальное число диапазона</param>
    /// <param name="maxNumber">Максимальное число диапазона</param>
    /// <returns>Максимальное количество попыток</returns>
    public int CalculateMaxAttempts(int minNumber, int maxNumber)
    {
        var range = maxNumber - minNumber + 1;
        return (int)Math.Ceiling(Math.Log2(range));
    }
}