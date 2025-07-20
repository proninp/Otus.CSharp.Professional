namespace HomeWork._05.Core.Models;

/// <summary>
/// Диапазон чисел для игры
/// </summary>
public sealed class NumberRange
{
    /// <summary>
    /// Создать диапазон чисел
    /// </summary>
    /// <param name="min">Минимальное значение</param>
    /// <param name="max">Максимальное значение</param>
    /// <exception cref="ArgumentException">Если минимальное значение больше максимального</exception>
    public NumberRange(int min, int max)
    {
        if (min > max)
            throw new ArgumentException("Минимальное значение не может быть больше максимального", nameof(min));
            
        Min = min;
        Max = max;
    }

    /// <summary>
    /// Минимальное значение диапазона
    /// </summary>
    public int Min { get; }

    /// <summary>
    /// Максимальное значение диапазона
    /// </summary>
    public int Max { get; }

    /// <summary>
    /// Размер диапазона
    /// </summary>
    public int Size => Max - Min + 1;

    /// <summary>
    /// Проверить, входит ли число в диапазон
    /// </summary>
    /// <param name="number">Проверяемое число</param>
    /// <returns>True, если число входит в диапазон</returns>
    public bool Contains(int number) => number >= Min && number <= Max;

    /// <summary>
    /// Создать новый диапазон с обновленным минимумом
    /// </summary>
    /// <param name="newMin">Новое минимальное значение</param>
    /// <returns>Новый диапазон</returns>
    public NumberRange WithMin(int newMin) => new(newMin, Max);

    /// <summary>
    /// Создать новый диапазон с обновленным максимумом
    /// </summary>
    /// <param name="newMax">Новое максимальное значение</param>
    /// <returns>Новый диапазон</returns>
    public NumberRange WithMax(int newMax) => new(Min, newMax);
}