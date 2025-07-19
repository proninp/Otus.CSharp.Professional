using HomeWork._05.Abstractions.Models;

namespace HomeWork._05.Core.Abstractions.Players;

public interface IPlayer
{
    int TryGuessNumber();

    int RiddleTheNumber();

    void Hint(GuessOutcome outcome);
}