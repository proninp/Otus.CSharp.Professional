using HomeWork._04.Abstractions;
using HomeWork._04.Interfaces;

namespace HomeWork._04.Models;

public class Necromant(
    string name,
    int health,
    int level,
    int agility,
    int intelligence,
    int strength,
    int undeadControlLevel,
    int cursePower)
    : GameCharacter(name, health, level, agility, intelligence, strength), IMyCloneable<Necromant>, ICloneable
{
    public int UndeadControlLevel { get; } = undeadControlLevel;

    public int CursePower { get; } = cursePower;

    public Necromant Clone()
    {
        return new Necromant(
            name: Name,
            health: Health,
            level: Level,
            agility: Agility,
            intelligence: Intelligence,
            strength: Strength,
            undeadControlLevel: UndeadControlLevel,
            cursePower: CursePower);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    /// <summary>
    /// Проверяет равенство текущего объекта с другим объектом Necromant.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если объекты равны, иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not Necromant other) return false;
        return UndeadControlLevel == other.UndeadControlLevel && CursePower == other.CursePower;
    }

    /// <summary>
    /// Возвращает хэш-код для текущего объекта.
    /// </summary>
    /// <returns>Хэш-код объекта.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), UndeadControlLevel, CursePower);
    }
}

