using HomeWork._04.Models;

// Демонстрация работы IMyCloneable на примере класса Warrior

var originalWarrior = new Warrior(
    name: "Arthur",
    health: 100,
    level: 5,
    agility: 10,
    intelligence: 7,
    strength: 15,
    armor: 8,
    weaponDamage: 12);

var clonedWarrior = originalWarrior.Clone();

Console.WriteLine("Оригинал воина:");
Console.WriteLine(
    $"Имя: {originalWarrior.Name}, Здоровье: {originalWarrior.Health}, Уровень: {originalWarrior.Level}, " +
    $"Ловкость: {originalWarrior.Agility}, Интеллект: {originalWarrior.Intelligence}, Сила: {originalWarrior.Strength}, " +
    $"Броня: {originalWarrior.Armor}, Урон оружия: {originalWarrior.WeaponDamage}");

Console.WriteLine("Клон воина:");
Console.WriteLine(
    $"Имя: {clonedWarrior.Name}, Здоровье: {clonedWarrior.Health}, Уровень: {clonedWarrior.Level}, " +
    $"Ловкость: {clonedWarrior.Agility}, Интеллект: {clonedWarrior.Intelligence}, Сила: {clonedWarrior.Strength}, " +
    $"Броня: {clonedWarrior.Armor}, Урон оружия: {clonedWarrior.WeaponDamage}");

// Демонстрация работы IMyCloneable на примере класса Mage

var originalMage = new Mage(
    name: "Merlin",
    health: 80,
    level: 10,
    agility: 12,
    intelligence: 20,
    strength: 5,
    mana: 100,
    new Spell(30, 5, 20, "Fireball"),
    new Spell(20, 3, 10, "Ice Spike")
);

var clonedMage = originalMage.Clone();

Console.WriteLine("\nОригинальный маг:");
Console.WriteLine(
    $"Имя: {originalMage.Name}, Здоровье: {originalMage.Health}, Уровень: {originalMage.Level}, " +
    $"Ловкость: {originalMage.Agility}, Интеллект: {originalMage.Intelligence}, Сила: {originalMage.Strength}, " +
    $"Мана: {originalMage.Mana}, Заклинания: {string.Join(", ", originalMage.Spells.Select(s => s.Name))}");

Console.WriteLine("Клон мага:");
Console.WriteLine(
    $"Имя: {clonedMage.Name}, Здоровье: {clonedMage.Health}, Уровень: {clonedMage.Level}, " +
    $"Ловкость: {clonedMage.Agility}, Интеллект: {clonedMage.Intelligence}, Сила: {clonedMage.Strength}, " +
    $"Мана: {clonedMage.Mana}, Заклинания: {string.Join(", ", clonedMage.Spells.Select(s => s.Name))}");

// Демонстрация работы IMyCloneable на примере класса Necromant

var originalNecromant = new Necromant(
    name: "Morgoth",
    health: 90,
    level: 8,
    agility: 8,
    intelligence: 18,
    strength: 6,
    undeadControlLevel: 4,
    cursePower: 13
);

var clonedNecromant = originalNecromant.Clone();

Console.WriteLine("\nОригинальный некромант:");
Console.WriteLine(
    $"Имя: {originalNecromant.Name}, Здоровье: {originalNecromant.Health}, Уровень: {originalNecromant.Level}, " +
    $"Ловкость: {originalNecromant.Agility}, Интеллект: {originalNecromant.Intelligence}, Сила: {originalNecromant.Strength}, " +
    $"Контроль нежити: {originalNecromant.UndeadControlLevel}, Сила проклятия: {originalNecromant.CursePower}");

Console.WriteLine("Клон некроманта:");
Console.WriteLine(
    $"Имя: {clonedNecromant.Name}, Здоровье: {clonedNecromant.Health}, Уровень: {clonedNecromant.Level}, " +
    $"Ловкость: {clonedNecromant.Agility}, Интеллект: {clonedNecromant.Intelligence}, Сила: {clonedNecromant.Strength}, " +
    $"Контроль нежити: {clonedNecromant.UndeadControlLevel}, Сила проклятия: {clonedNecromant.CursePower}");
