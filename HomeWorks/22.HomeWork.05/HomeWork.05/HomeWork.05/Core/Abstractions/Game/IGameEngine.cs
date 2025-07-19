using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Players;

namespace HomeWork._05.Core.Abstractions.Game;

public interface IGameEngine
{
    void Play(GameMode mode);
}