using HomeWork._05.Core.Abstractions.Players;

namespace HomeWork._05.Services;

public class HumanPlayer(int minNumber, int maxNumber) : Player(minNumber, maxNumber)
{
    public override int TryGuessNumber()
    {
        throw new NotImplementedException();
    }

    public override int RiddleTheNumber()
    {
        throw new NotImplementedException();
    }
}