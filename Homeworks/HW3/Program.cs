using System;
using System.Collections.Generic;

abstract class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count;

    public Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;
    }

    public string Name => name;
    public int Hp => hp;
    public int Power => power;

    public static int HowMany()
    {
        return count;
    }

    public static bool IsValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    public abstract void Attack(Character target);

    public override string ToString()
    {
        return $"{name} (HP: {hp})";
    }

    public override bool Equals(object obj)
    {
        if (obj is Character other)
        {
            return this.name == other.name && this.hp == other.hp && this.power == other.power;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, hp, power);
    }

    public static bool operator ==(Character left, Character right)
    {
        if (left is null || right is null) return left is null && right is null;
        return left.Equals(right);
    }

    public static bool operator !=(Character left, Character right)
    {
        return !(left == right);
    }
}

class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"Игрок {Name} наносит удар");
        target.TakeDamage(Power);
    }
}

class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"Враг {Name} атакует");
        target.TakeDamage(Power);
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player("Герой", 100, 20);
        Enemy enemy = new Enemy("Враг", 80, 15);

        Console.WriteLine($"Создано персонажей: {Character.HowMany()}");
        Console.WriteLine($"Проверка статов (100, 20): {Character.IsValidStats(100, 20)}");
        Console.WriteLine($"Проверка статов (-100, 20): {Character.IsValidStats(-100, 20)}");
        Console.WriteLine();

        List<Character> fighters = new List<Character> { hero, enemy };

        foreach (var f in fighters)
        {
            Console.WriteLine(f);
        }
        Console.WriteLine();

        while (hero.IsAlive() && enemy.IsAlive())
        {
            hero.Attack(enemy);
            Console.WriteLine(enemy);
            if (!enemy.IsAlive()) break;

            enemy.Attack(hero);
            Console.WriteLine(hero);
            if (!hero.IsAlive()) break;

            Console.WriteLine("-------------------");
        }

        Console.WriteLine();
        if (hero.IsAlive())
            Console.WriteLine("Победил Герой");
        else
            Console.WriteLine("Победил Враг");

        Console.WriteLine();
        Console.WriteLine($"hero == enemy: {hero == enemy}");
        Console.WriteLine($"hero != enemy: {hero != enemy}");
    }
}