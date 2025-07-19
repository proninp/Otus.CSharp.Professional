using HomeWork._05.Abstractions.Models;

namespace HomeWork._05.Core.Abstractions.Game;

public interface IGameResultEvaluator
{
    GuessResult Evaluate(int secretNumber, int playerGuess);
}