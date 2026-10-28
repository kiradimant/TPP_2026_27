using System;
class Character
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
		count++:
	}
	public void Attack(Character target)
	{
		target.hp -= this.power;
		Console.WriteLine($"{this.name} атакует {target.name} и наносит {this.power}");
	}
	public void GetStatus()
	{
		Console.WriteLine($"{this.name}: HP = {this.hp}");
	}
	public static int HowMany()
	{
		return count;
	}
	public static bool IsValidStats(int hp, int power)
	{
		return hp > 0 && power > 0;
	}
}
class Enemy : Character
{
	public Enemy(string name, int hp, int power) : base(name, hp, power)
    {

    }
	public new void Attack(Character target)
    {
		Console.WriteLine($"Враг {this.name} атакуетт");
		base.Attack(target);
    }
}
class Program
{
	static void Main()
    {
		Player hero = new Player("герой", 100, 20);
		Enemy enemy = new Enemy("враг", 80, 10);

		Console.WriteLine($"всего созданных персонажей {Character.HowMany()}");
		Console.WriteLine($"статус(100, 20) {Character.IsValidStats(100, 20)} ");
		Console.WriteLine($"статус(-100, 20) {Character.IsValidStats(-100, 20)} ");

		hero.GetStatus();
		enemy.GetStatus();
		hero.Attack(enemy);
		enemy.GetStatus();
		enemy.Attack(hero);
		hero.GetStatus();


	}
}