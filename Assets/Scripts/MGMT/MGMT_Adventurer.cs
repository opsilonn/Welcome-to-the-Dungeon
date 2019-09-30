using System.Collections.Generic;


public static class MGMT_Adventurer
{
    public static List<string> GetAdventurersNames()
    {
        List<Adventurer> adventurers = MGMT_Xml.GetAdventurers();
        List<string> list = new List<string>();

        foreach (Adventurer adventurer in adventurers)
            list.Add(adventurer.name);
        
        return list;
    }
}
