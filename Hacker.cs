public class Hacker : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(int BankParam)
    {
        BankParam -= SkillLevel;
        Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points.");
        if (BankParam <= 0)
        {
            Console.WriteLine($"{Name} has disabled the alarm system.");
        }
    }
}