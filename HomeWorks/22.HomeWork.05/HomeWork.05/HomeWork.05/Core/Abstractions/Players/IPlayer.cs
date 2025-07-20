using HomeWork._05.Core.Models;

namespace HomeWork._05.Core.Abstractions.Players;

/// <summary>
/// Комбинированный интерфейс для универсального игрока
/// </summary>
public interface IPlayer : INumberGuesser, INumberRiddler
{
}