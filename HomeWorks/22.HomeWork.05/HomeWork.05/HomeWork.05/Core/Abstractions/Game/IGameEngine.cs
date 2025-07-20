using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Models;

namespace HomeWork._05.Core.Abstractions.Game;

/// <summary>
/// Улучшенный движок игры с разделенными ответственностями
/// </summary>
public interface IGameEngine
{
    /// <summary>
    /// Запустить игру в указанном режиме
    /// </summary>
    /// <param name="mode">Режим игры</param>
    void Play(GameMode mode = GameMode.ComputerAsRiddlerVsPlayer);
}