using HomeWork._05.Abstractions.Models;
using HomeWork._05.Settings;
using Microsoft.Extensions.Options;

namespace HomeWork._05.Core.Abstractions.Players;

public abstract class Player(IOptions<GameSettings> settings) : IPlayer
{
    private protected int MinNumber { get; set; } = settings.Value.MinNumber;

    private protected int MaxNumber { get; set; } = settings.Value.MaxNumber;

    public abstract int TryGuessNumber();

    public abstract int RiddleTheNumber();
    
    public abstract void Hint(GuessOutcome outcome);
}