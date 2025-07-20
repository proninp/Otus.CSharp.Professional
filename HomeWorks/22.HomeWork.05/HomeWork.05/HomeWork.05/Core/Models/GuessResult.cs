namespace HomeWork._05.Core.Models;

/// <summary>
/// Иммутабельный результат попытки угадывания
/// </summary>
public sealed class GuessResult(GuessOutcome outcome)
{
    /// <summary>
    /// Результат сравнения угаданного числа с загаданным
    /// </summary>
    public GuessOutcome Outcome { get; } = outcome;
    
    /// <summary>
    /// Проверить, угадано ли число правильно
    /// </summary>
    public bool IsCorrect => Outcome == GuessOutcome.Correct;
}