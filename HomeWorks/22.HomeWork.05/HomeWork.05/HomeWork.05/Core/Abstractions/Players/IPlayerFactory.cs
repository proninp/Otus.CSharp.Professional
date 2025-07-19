using HomeWork._05.Abstractions.Models;

namespace HomeWork._05.Core.Abstractions.Players;

public interface IPlayerFactory
{
    (Player player1, Player player2) CreatePlayers(GameMode mode);
}