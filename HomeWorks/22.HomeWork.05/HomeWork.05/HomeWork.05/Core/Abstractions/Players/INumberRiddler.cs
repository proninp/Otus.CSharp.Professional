namespace HomeWork._05.Core.Abstractions.Players;

/// <summary>
/// Интерфейс для игрока, который может загадывать числа
/// </summary>
public interface INumberRiddler
{
    /// <summary>
    /// Загадать число в заданном диапазоне
    /// </summary>
    /// <returns>Загаданное число</returns>
    int RiddleNumber();
}