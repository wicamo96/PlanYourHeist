public class Muscle : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(int BankParam)
    {
        BankParam -= SkillLevel;
        Console.WriteLine($"{Name} is tackling the security guards. Decreased security {SkillLevel} points.");
        if (BankParam <= 0)
        {
            Console.WriteLine($"{Name} has disabled the security guards.");
        }
    }
}