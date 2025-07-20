namespace HomeWork._05.Core.Models;

/// <summary>
/// Результат игрового раунда
/// </summary>
public sealed class GameRoundResult
{
    /// <summary>
    /// Создать результат раунда
    /// </summary>
    /// <param name="secretNumber">Загаданное число</param>
    /// <param name="attemptsUsed">Количество использованных попыток</param>
    /// <param name="isSuccess">Успешно ли завершен раунд</param>
    public GameRoundResult(int secretNumber, int attemptsUsed, bool isSuccess)
    {
        SecretNumber = secretNumber;
        AttemptsUsed = attemptsUsed;
        IsSuccess = isSuccess;
    }
    
    /// <summary>
    /// Загаданное число
    /// </summary>
    public int SecretNumber { get; }

    /// <summary>
    /// Количество использованных попыток
    /// </summary>
    public int AttemptsUsed { get; }

    /// <summary>
    /// Успешно ли завершен раунд
    /// </summary>
    public bool IsSuccess { get; }
}