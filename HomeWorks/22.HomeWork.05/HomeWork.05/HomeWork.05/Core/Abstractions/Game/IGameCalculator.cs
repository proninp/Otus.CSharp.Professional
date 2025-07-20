namespace HomeWork._05.Core.Abstractions.Game;

/// <summary>
/// Сервис для вычисления параметров игры
/// </summary>
public interface IGameCalculator
{
    /// <summary>
    /// Вычислить максимальное количество попыток для угадывания числа
    /// </summary>
    /// <param name="minNumber">Минимальное число диапазона</param>
    /// <param name="maxNumber">Максимальное число диапазона</param>
    /// <returns>Оптимальное количество попыток</returns>
    int CalculateMaxAttempts(int minNumber, int maxNumber);
}