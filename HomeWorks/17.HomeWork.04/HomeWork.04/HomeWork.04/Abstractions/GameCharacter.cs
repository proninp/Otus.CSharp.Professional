using HomeWork._04.Interfaces;

namespace HomeWork._04.Abstractions;

/// <summary>
/// Абстрактный игровой персонаж с характеристиками ловкости, интеллекта и силы.
/// </summary>
/// <param name="name">Имя персонажа.</param>
/// <param name="health">Здоровье персонажа.</param>
/// <param name="level">Уровень персонажа.</param>
/// <param name="agility">Ловкость персонажа.</param>
/// <param name="intelligence">Интеллект персонажа.</param>
/// <param name="strength">Сила персонажа.</param>
public abstract class GameCharacter(string name, int health, int level, int agility, int intelligence, int strength)
    : GameUnit(name, health, level)
{
    /// <summary>
    /// Ловкость персонажа.
    /// </summary>
    public int Agility { get; private protected set; } = agility;

    /// <summary>
    /// Интеллект персонажа.
    /// </summary>
    public int Intelligence { get; private protected set; } = intelligence;

    /// <summary>
    /// Сила персонажа.
    /// </summary>
    public int Strength { get; private protected set; } = strength;

    /// <summary>
    /// Проверяет равенство текущего объекта с другим объектом GameCharacter.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если объекты равны, иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not GameCharacter other) return false;
        return Agility == other.Agility &&
               Intelligence == other.Intelligence &&
               Strength == other.Strength;
    }

    /// <summary>
    /// Возвращает хэш-код для текущего объекта.
    /// </summary>
    /// <returns>Хэш-код объекта.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Agility, Intelligence, Strength);
    }
}

