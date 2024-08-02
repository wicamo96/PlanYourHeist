public class LockSpecialist : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(int BankParam)
    {
        BankParam -= SkillLevel;
        Console.WriteLine($"{Name} is attempting to crack the safe. Decreased security {SkillLevel} points.");
        if (BankParam <= 0)
        {
            Console.WriteLine($"{Name} has cracked the safe.");
        }
    }
}