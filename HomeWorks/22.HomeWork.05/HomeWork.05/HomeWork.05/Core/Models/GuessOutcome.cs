namespace HomeWork._05.Core.Models;

/// <summary>
/// Результат сравнения угаданного числа с загаданным
/// </summary>
public enum GuessOutcome
{
    /// <summary>
    /// Угаданное число слишком маленькое
    /// </summary>
    TooLow,
    /// <summary>
    /// Угаданное число слишком большое
    /// </summary>
    TooHigh,
    /// <summary>
    /// Число угадано правильно
    /// </summary>
    Correct
}