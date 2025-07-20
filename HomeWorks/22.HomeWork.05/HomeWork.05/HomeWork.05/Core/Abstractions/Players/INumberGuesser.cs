using HomeWork._05.Core.Models;

namespace HomeWork._05.Core.Abstractions.Players;

/// <summary>
/// Интерфейс для игрока, который может угадывать числа
/// </summary>
public interface INumberGuesser
{
    /// <summary>
    /// Попытка угадать число
    /// </summary>
    /// <returns>Предполагаемое число</returns>
    int GuessNumber();

    /// <summary>
    /// Получить подсказку о результате угадывания
    /// </summary>
    /// <param name="outcome">Результат предыдущей попытки</param>
    void ReceiveHint(GuessOutcome outcome);
}