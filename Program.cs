using System;
using System.Linq;

List<IRobber> Roladex = new List<IRobber>(){
    new Hacker {
        Name = "Bippity Boppity",
        SkillLevel = 50,
        PercentageCut = 25
    },
    new Hacker {
        Name = "Jimbo Scrimbo",
        SkillLevel = 30,
        PercentageCut = 15
    },
    new LockSpecialist {
        Name = "Clicky McGee",
        SkillLevel = 60,
        PercentageCut = 30
    },
    new LockSpecialist {
        Name = "Bing Bang",
        SkillLevel = 70,
        PercentageCut = 35
    },
    new Muscle {
        Name = "Ronnie Coleman",
        SkillLevel = 75,
        PercentageCut = 40
    },
    new Muscle {
        Name = "Muscles Man",
        SkillLevel = 50,
        PercentageCut = 25
    }
};

Console.WriteLine("Plan Your Heist!");
while (true)
{
    Console.WriteLine($"You have {Roladex.Count} operatives in your roladex.");

    Console.WriteLine("Enter the name of a new operative: ");
    string name = Console.ReadLine();

    if (name == "")
    {
        break;
    }

    Console.WriteLine($"Select {name}'s specialty: ");
    Console.WriteLine("Hacker (Disables alarms)");
    Console.WriteLine("Muscle (Disables guards)");
    Console.WriteLine("Lock Specialist (cracks vault)");
    string specialty = Console.ReadLine().ToLower();

    Console.WriteLine($"Enter {name}'s skill level as a number from 1 - 100: ");
    int skilllevel = int.Parse(Console.ReadLine());

    Console.WriteLine($"Enter {name}'s percentage cut as a number from 1 - 100: ");
    int percentagecut = int.Parse(Console.ReadLine());

    switch (specialty)
    {
        case "hacker":
            Roladex.Add(new Hacker
            {
                Name = name,
                SkillLevel = skilllevel,
                PercentageCut = percentagecut
            });
            break;
        case "muscle":
            Roladex.Add(new Muscle
            {
                Name = name,
                SkillLevel = skilllevel,
                PercentageCut = percentagecut
            });
            break;
        case "lock specialist":
            Roladex.Add(new LockSpecialist
            {
                Name = name,
                SkillLevel = skilllevel,
                PercentageCut = percentagecut
            });
            break;
    }
}

Random random = new Random();

Bank BankOfHeists = new Bank
{
    CashOnHand = random.Next(50000, 1000000),
    AlarmScore = random.Next(1, 101),
    VaultScore = random.Next(1, 101),
    SecurityGuardScore = random.Next(1, 101)
};

Dictionary<string, int> ReconReport = new Dictionary<string, int> {{"Alarm", BankOfHeists.AlarmScore}, {"Vault", BankOfHeists.VaultScore}, {"Guards", BankOfHeists.SecurityGuardScore}};
var SortedReconReport = from entry in ReconReport orderby entry.Value ascending select entry;

Console.WriteLine($"Most secure: {SortedReconReport.First().Key}");
Console.WriteLine($"Least secure: {SortedReconReport.Last().Key}");

Roladex.ForEach(member =>
{
    int index = Roladex.IndexOf(member);
    Console.WriteLine($"Operative {index}: {member.Name}, Specialty: {member.GetType().ToString()}, Skill Level: {member.SkillLevel}, Cut: {member.PercentageCut}");
});

List<IRobber> Crew = new List<IRobber>();

while (true)
{
    Console.WriteLine("Enter operative number that you'd like to add to your crew: ");
    string selection = Console.ReadLine();
    if (!int.TryParse(selection, out int output))
    {
        break;
    }
    int IntSelection = int.Parse(selection);
    IRobber CrewMember = Roladex[IntSelection];
    Crew.Add(CrewMember);

    Roladex.ForEach(member =>
    {
        if (!Crew.Contains(member) || Crew.Sum(member => member.PercentageCut) + member.PercentageCut !> 100)
        {
        int index = Roladex.IndexOf(member);
        Console.WriteLine($"Operative {index}: {member.Name}, Specialty: {member.GetType().ToString()}, Skill Level: {member.SkillLevel}, Cut: {member.PercentageCut}");
        }
    });
};

Crew.ForEach(member => {
    switch (member.GetType().ToString())
    {
        case "Hacker":
            member.PerformSkill(BankOfHeists.AlarmScore);
            BankOfHeists.AlarmScore -= member.SkillLevel;
            break;
        case "Muscle":
            member.PerformSkill(BankOfHeists.SecurityGuardScore);
            BankOfHeists.SecurityGuardScore -= member.SkillLevel;
            break;
        case "LockSpecialist":
            member.PerformSkill(BankOfHeists.VaultScore);
            BankOfHeists.VaultScore -= member.SkillLevel;
            break;
    }

});

if (BankOfHeists.AlarmScore <= 0 && BankOfHeists.SecurityGuardScore <= 0 && BankOfHeists.VaultScore <= 0)
{
    BankOfHeists.IsSecure = false;
}
else
{
    BankOfHeists.IsSecure = true;
}

if (BankOfHeists.IsSecure == true)
{
    Console.WriteLine("You failed, straight to jail!!");
}
else
{
    int YourCut = BankOfHeists.CashOnHand;
    Console.WriteLine("Heist successful!");
    Crew.ForEach(member =>{
        int MemberCut = BankOfHeists.CashOnHand * member.PercentageCut / 100;
        Console.WriteLine($"{member.Name}'s cut: {MemberCut}");
        YourCut -= MemberCut;
    });
    Console.WriteLine($"Your cut: {YourCut}");
}

// List<TeamMember> DreamTeam = new List<TeamMember>();

// Console.WriteLine("Plan Your Heist!");

// Console.WriteLine("Enter bank difficulty: ");
// int InitialBankDifficulty = int.Parse(Console.ReadLine());

// string name = null;

// while (true)
// {
//     Console.WriteLine("Enter team member's name: ");
//     name = Console.ReadLine();

//     if (name == "")
//     {
//         break;
//     }

//     Console.WriteLine($"Enter {name}'s skill level: ");
//     int skill = int.Parse(Console.ReadLine());

//     while (skill == null)
//     {
//         Console.WriteLine($"Enter {name}'s skill level: ");
//         skill = int.Parse(Console.ReadLine());
//     }

//     Console.WriteLine($"Enter {name}'s courage factor: ");
//     double courage = double.Parse(Console.ReadLine());

//     while (courage == null)
//     {
//         Console.WriteLine($"Enter {name}'s courage factor: ");
//         courage = double.Parse(Console.ReadLine());
//     }
//     TeamMember NewMember = new TeamMember (name, skill, Math.Round(courage, 2));
//     DreamTeam.Add(NewMember);
// }

// Console.WriteLine("Enter number of trials you'd like to run: ");
// int trials = int.Parse(Console.ReadLine());

// Dictionary<string, int> ScoreCard = new Dictionary<string, int>();

// for (int i = 0; i < trials; i++)
// {
//     Console.WriteLine($"Trial {i + 1}");
//     Random random = new Random();
//     int LuckValue = random.Next(-10, 11);

//     int BankDifficulty = InitialBankDifficulty + LuckValue;

//     Console.WriteLine($"Your team is {DreamTeam.Count()} members strong");

//     int power = DreamTeam.Sum(member => member.SkillLevel);

//     Console.WriteLine($"Your team's combined skill level is: {power}");

//     Console.WriteLine($"The bank's difficulty level is: {BankDifficulty}");

//     if (power >= BankDifficulty)
//     {
//         Console.WriteLine("Heist Success!");
//         if (ScoreCard.ContainsKey("Success"))
//         {
//             ScoreCard["Success"] += 1;
//         }
//         else
//         {
//             ScoreCard.Add("Success", 1);
//         }

//     }
//     else
//     {
//         Console.WriteLine("Believe it or not, straight to jail!");
//         if (ScoreCard.ContainsKey("Failure"))
//         {
//             ScoreCard["Failure"] += 1;
//         }
//         else
//         {
//             ScoreCard.Add("Failure", 1);
//         }
//     }
//     Console.WriteLine("-----------------------------------------------");
// }

// Console.WriteLine($"Successes: {ScoreCard["Success"]}");
// Console.WriteLine($"Failures: {ScoreCard["Failure"]}");