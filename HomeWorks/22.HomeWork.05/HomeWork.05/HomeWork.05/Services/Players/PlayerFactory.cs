using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Players;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork._05.Services.Players;

public class PlayerFactory(IServiceProvider serviceProvider) : IPlayerFactory
{
    public (Player player1, Player player2) CreatePlayers(GameMode mode)
    {
        return mode switch
        {
            GameMode.ComputerAsRiddlerVsPlayer =>
                (serviceProvider.GetRequiredService<ComputerPlayer>(),
                    serviceProvider.GetRequiredService<HumanPlayer>()),
            GameMode.PlayerAsRiddlerVsComputer =>
                (serviceProvider.GetRequiredService<HumanPlayer>(),
                    serviceProvider.GetRequiredService<ComputerPlayer>()),
            GameMode.PlayerVsPlayer =>
                (serviceProvider.GetRequiredService<HumanPlayer>(),
                    serviceProvider.GetRequiredService<HumanPlayer>()),
            _ => throw new ArgumentOutOfRangeException(nameof(mode),
                $"Неподдерживаемый режим игры: {mode}")
        };
    }
}