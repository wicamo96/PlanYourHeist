using System;

Console.WriteLine("Plan Your Heist!");

Console.WriteLine("Enter team member's name: ");
string name = Console.ReadLine();

while (name == "")
{
    Console.WriteLine("Enter team member's name: ");
    name = Console.ReadLine();
}

Console.WriteLine($"Enter {name}'s skill level: ");
int skill = int.Parse(Console.ReadLine());

while (skill == null)
{
    Console.WriteLine($"Enter {name}'s skill level: ");
    skill = int.Parse(Console.ReadLine());
}

Console.WriteLine($"Enter {name}'s courage factor: ");
double courage = double.Parse(Console.ReadLine());

while (courage == null)
{
    Console.WriteLine($"Enter {name}'s courage factor: ");
    courage = double.Parse(Console.ReadLine());
}

Console.WriteLine($"{name}, skill level: {skill}, courage factor: {courage}");