using HomeWork._04.Enums;

namespace HomeWork._04.Models;

/// <summary>
/// Класс, представляющий магическое заклинание.
/// </summary>
/// <param name="power">Сила заклинания.</param>
/// <param name="minimumLevel">Минимальный уровень для использования.</param>
/// <param name="manaCost">Стоимость маны.</param>
/// <param name="name">Название заклинания.</param>
public class Spell(int power, int minimumLevel, int manaCost, string name)
{
    /// <summary>
    /// Тип заклинания.
    /// </summary>
    public SpellType SpellType { get; set; } = SpellType.Fire;
    
    /// <summary>
    /// Сила заклинания.
    /// </summary>
    public int Power { get; set; } = power;

    /// <summary>
    /// Минимальный уровень для использования заклинания.
    /// </summary>
    public int MinimumLevel { get; set; } = minimumLevel;

    /// <summary>
    /// Стоимость маны.
    /// </summary>
    public int ManaCost { get; set; } = manaCost;

    /// <summary>
    /// Название заклинания.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Проверяет равенство текущего объекта с другим объектом Spell.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если объекты равны, иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Spell other) return false;
        return SpellType == other.SpellType &&
               Power == other.Power &&
               MinimumLevel == other.MinimumLevel &&
               ManaCost == other.ManaCost &&
               Name == other.Name;
    }

    /// <summary>
    /// Возвращает хэш-код для текущего объекта.
    /// </summary>
    /// <returns>Хэш-код объекта.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(SpellType, Power, MinimumLevel, ManaCost, Name);
    }
}
