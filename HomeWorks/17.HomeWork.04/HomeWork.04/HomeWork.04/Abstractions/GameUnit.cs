using HomeWork._04.Interfaces;

namespace HomeWork._04.Abstractions;

/// <summary>
/// Абстрактный базовый класс для игровых юнитов.
/// </summary>
/// <param name="name">Имя юнита.</param>
/// <param name="health">Здоровье юнита.</param>
/// <param name="level">Уровень юнита.</param>
public abstract class GameUnit(string name, int health, int level)
{
    /// <summary>
    /// Имя юнита.
    /// </summary>
    public string Name { get; private protected set; } = name;

    /// <summary>
    /// Здоровье юнита.
    /// </summary>
    public int Health { get; private protected set; } = health;

    /// <summary>
    /// Уровень юнита.
    /// </summary>
    public int Level { get; private protected set; } = level > 0 ? level : 1;

    /// <summary>
    /// Проверяет равенство текущего объекта с другим объектом GameUnit.
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns>True, если объекты равны, иначе False.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not GameUnit other) return false;
        return Name == other.Name && Health == other.Health && Level == other.Level;
    }

    /// <summary>
    /// Возвращает хэш-код для текущего объекта.
    /// </summary>
    /// <returns>Хэш-код объекта.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Health, Level);
    }
}

