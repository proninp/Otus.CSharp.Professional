using HomeWork._05.Core.Abstractions;
using HomeWork._05.Core.Abstractions.Players;
using HomeWork._05.Core.Abstractions.Utils;

namespace HomeWork._05.Services;

public class ComputerPlayer(
    int minNumber,
    int maxNumber,
    INumberGenerator numberGenerator,
    INumberGuesser numberGuesser)
    : Player(minNumber, maxNumber)
{
    public override int TryGuessNumber() =>
        numberGuesser.Guess(MinNumber, MaxNumber);

    public override int RiddleTheNumber() =>
        numberGenerator.GetRandomNumber(MinNumber, MaxNumber);
}