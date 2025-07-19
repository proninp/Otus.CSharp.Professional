using HomeWork._05.Abstractions.Models;
using HomeWork._05.Core.Abstractions.Game;

namespace HomeWork._05.Services.Game;

public class GameResultEvaluator : IGameResultEvaluator
{
    public GuessResult Evaluate(int secretNumber, int playerGuess)
    {
        var guessOutcome = secretNumber == playerGuess
            ? GuessOutcome.Correct
            : playerGuess > secretNumber
                ? GuessOutcome.TooHigh
                : GuessOutcome.TooLow;
        return new GuessResult(guessOutcome);
    }
}