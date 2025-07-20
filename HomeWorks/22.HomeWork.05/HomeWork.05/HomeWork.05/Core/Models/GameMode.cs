namespace HomeWork._05.Core.Models;

/// <summary>
/// Режимы игры
/// </summary>
public enum GameMode
{
    /// <summary>
    /// Компьютер загадывает, игрок угадывает
    /// </summary>
    ComputerAsRiddlerVsPlayer = 1,
    /// <summary>
    /// Игрок загадывает, компьютер угадывает
    /// </summary>
    PlayerAsRiddlerVsComputer = 2,
    /// <summary>
    /// Игрок против игрока
    /// </summary>
    PlayerVsPlayer = 3,
}