public class TeamMember
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double CourageFactor { get; set; }

    public TeamMember (string name, int skilllvl, double couragefact)
    {
        Name = name;
        SkillLevel = skilllvl;
        CourageFactor = couragefact;
    }
}