using HomeWork._04.Abstractions;
using HomeWork._04.Interfaces;

namespace HomeWork._04.Models;

public class Mage(
    string name,
    int health,
    int level,
    int agility,
    int intelligence,
    int strength,
    int mana,
    params Spell[] spells)
    : GameCharacter(name, health, level, agility, intelligence, strength), IMyCloneable<Mage>, ICloneable
{
    public int Mana { get; } = mana;

    public List<Spell> Spells { get; } = new(spells);

    public Mage Clone()
    {
        return new Mage(
            name: Name,
            health: Health,
            level: Level,
            agility: Agility,
            intelligence: Intelligence,
            strength: Strength,
            mana: Mana,
            spells: Spells.ToArray());
    }
    
    object ICloneable.Clone()
    {
        return Clone();
    }

    /// <summary>
    /// Проверяет равенство текущего объекта с другим объектом Mage.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если объекты равны, иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not Mage other) return false;
        if (Mana != other.Mana) return false;
        if (Spells.Count != other.Spells.Count) return false;
        for (var i = 0; i < Spells.Count; i++)
            if (!Spells[i].Equals(other.Spells[i])) return false;
        return true;
    }

    /// <summary>
    /// Возвращает хэш-код для текущего объекта.
    /// </summary>
    /// <returns>Хэш-код объекта.</returns>
    public override int GetHashCode()
    {
        var hash = HashCode.Combine(base.GetHashCode(), mana);
        foreach (var spell in spells)
            hash = HashCode.Combine(hash, spell);
        return hash;
    }
}
