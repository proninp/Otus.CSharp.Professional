using HomeWork._04.Models;

namespace HomeWork._04.Tests;

public class PrototipeTests
{
    [Fact]
    public void Warrior_Clone_Equals_Original()
    {
        var original = new Warrior("Test", 100, 1, 5, 5, 5, 10, 20);
        var clone = original.Clone();

        Assert.NotSame(original, clone);
        Assert.Equal(original, clone);
        Assert.Equal(original.GetHashCode(), clone.GetHashCode());
    }

    [Fact]
    public void Mage_Clone_Equals_Original()
    {
        var spell1 = new Spell(10, 1, 5, "Fireball");
        var spell2 = new Spell(20, 2, 10, "Ice Spike");
        var original = new Mage("Mage", 80, 2, 7, 15, 4, 50, spell1, spell2);
        var clone = original.Clone();

        Assert.NotSame(original, clone);
        Assert.Equal(original, clone);
        Assert.Equal(original.GetHashCode(), clone.GetHashCode());
    }

    [Fact]
    public void Necromant_Clone_Equals_Original()
    {
        var original = new Necromant("Necro", 90, 3, 6, 12, 5, 3, 8);
        var clone = original.Clone();

        Assert.NotSame(original, clone);
        Assert.Equal(original, clone);
        Assert.Equal(original.GetHashCode(), clone.GetHashCode());
    }

    [Fact]
    public void Spell_Equals_And_HashCode()
    {
        var spell1 = new Spell(10, 1, 5, "Fireball") { SpellType = Enums.SpellType.Fire };
        var spell2 = new Spell(10, 1, 5, "Fireball") { SpellType = Enums.SpellType.Fire };
        var spell3 = new Spell(20, 2, 10, "Ice Spike") { SpellType = Enums.SpellType.Water };

        Assert.Equal(spell1, spell2);
        Assert.Equal(spell1.GetHashCode(), spell2.GetHashCode());
        Assert.NotEqual(spell1, spell3);
    }

    [Fact]
    public void Mage_Clone_Is_Deep()
    {
        var spell = new Spell(10, 1, 5, "Fireball");
        var mage = new Mage("Mage", 80, 2, 7, 15, 4, 50, spell);
        var clone = mage.Clone();

        // Проверяем, что список заклинаний склонирован (не тот же объект)
        Assert.NotSame(mage.Spells, clone.Spells);
        // Проверяем, что элементы списка равны, но могут быть теми же объектами (поверхностное копирование Spell)
        Assert.Equal(mage.Spells[0], clone.Spells[0]);
    }
}