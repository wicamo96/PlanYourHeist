using System;

List<TeamMember> DreamTeam = new List<TeamMember>();

Console.WriteLine("Plan Your Heist!");

string name = null;

while (true)
{
    Console.WriteLine("Enter team member's name: ");
    name = Console.ReadLine();

    if (name == "")
    {
        break;
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
    TeamMember NewMember = new TeamMember (name, skill, Math.Round(courage, 2));
    DreamTeam.Add(NewMember);
}

Console.WriteLine("Enter number of trials you'd like to run: ");
string response = Console.ReadLine();
int trials = int.Parse(response);

for (int i = 0; i < trials; i++)
{
    Console.WriteLine($"Trial {i + 1}");
    Random random = new Random();
    int LuckValue = random.Next(-10, 11);

    int BankDifficulty = 100;

    BankDifficulty += LuckValue;

    Console.WriteLine($"Your team is {DreamTeam.Count()} members strong");

    int power = DreamTeam.Sum(member => member.SkillLevel);

    Console.WriteLine($"Your team's combined skill level is: {power}");

    Console.WriteLine($"The bank's difficulty level is: {BankDifficulty}");

    if (power >= BankDifficulty)
    {
        Console.WriteLine("Heist Success!");
    }
    else
    {
        Console.WriteLine("Believe it or not, straight to jail!");
    }
    Console.WriteLine("-----------------------------------------------");
}
