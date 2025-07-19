using HomeWork._05.Core.Abstractions.Utils;

namespace HomeWork._05.Services.Utils;

public class NumberGuesser : INumberGuesser
{
    public int Guess(int minNumber, int maxNumber) =>
        (maxNumber + minNumber) / 2;
}