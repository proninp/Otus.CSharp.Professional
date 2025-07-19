using HomeWork._05.Abstractions.Models;

namespace HomeWork._05.Abstractions;

public interface IGameResultEvaluator
{
    GuessResult Evaluate(int secretNumber, int playerGuess);
}