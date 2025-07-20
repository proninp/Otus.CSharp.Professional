using HomeWork._05.Core.Abstractions.Game;
using HomeWork._05.Core.Models;

namespace HomeWork._05.Services.Game;

/// <summary>
/// Реализация оценки игрового результата
/// </summary>
public sealed class GameResultEvaluator : IGameResultEvaluator
{
    /// <summary>
    /// Определяет результат попытки угадывания числа
    /// </summary>
    /// <param name="secretNumber">Загаданное число</param>
    /// <param name="playerGuess">Число, предложенное игроком</param>
    /// <returns>
    /// Возвращает GuessResult с одним из вариантов:
    /// - Correct: если игрок угадал число
    /// - TooHigh: если предположение больше загаданного числа
    /// - TooLow: если предположение меньше загаданного числа
    /// </returns>
    public GuessResult Evaluate(int secretNumber, int playerGuess)
    {
        var guessOutcome = secretNumber == playerGuess
            ? GuessOutcome.Correct
            : playerGuess > secretNumber
                ? GuessOutcome.TooHigh
                : GuessOutcome.TooLow;
        return new GuessResult(guessOutcome);
    }
}