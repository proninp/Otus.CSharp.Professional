using HomeWork._05.Core.Models;

namespace HomeWork._05.Core.Abstractions.Game;

/// <summary>
/// Интерфейс для оценки результата игровой попытки
/// </summary>
public interface IGameResultEvaluator
{
    /// <summary>
    /// Сравнивает загаданное число с предположением игрока
    /// </summary>
    /// <param name="secretNumber">Загаданное число</param>
    /// <param name="playerGuess">Предположение игрока</param>
    /// <returns>Результат попытки в виде объекта GuessResult</returns>
    GuessResult Evaluate(int secretNumber, int playerGuess);
}