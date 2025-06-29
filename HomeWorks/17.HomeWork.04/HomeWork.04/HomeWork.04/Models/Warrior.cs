using HomeWork._04.Abstractions;
using HomeWork._04.Interfaces;

namespace HomeWork._04.Models;

public class Warrior(
    string name,
    int health,
    int level,
    int agility,
    int intelligence,
    int strength,
    int armor,
    int weaponDamage)
    : GameCharacter(name, health, level, agility, intelligence, strength), IMyCloneable<Warrior>, ICloneable
{
    public int Armor { get; } = armor;

    public int WeaponDamage { get; } = weaponDamage;

    public Warrior Clone()
    {
        return new Warrior(
            name: Name,
            health: Health,
            level: Level,
            agility: Agility,
            intelligence: Intelligence,
            strength: Strength,
            armor: Armor,
            weaponDamage: WeaponDamage);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    /// <summary>
    /// Проверяет равенство текущего объекта с другим объектом Warrior.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если объекты равны, иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not Warrior other) return false;
        return Armor == other.Armor && WeaponDamage == other.WeaponDamage;
    }

    /// <summary>
    /// Возвращает хэш-код для текущего объекта.
    /// </summary>
    /// <returns>Хэш-код объекта.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Armor, WeaponDamage);
    }
}

