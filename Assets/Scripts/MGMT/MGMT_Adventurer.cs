 using System.Collections.Generic;


public static class MGMT_Adventurer
{
    /// <summary>
    /// Returns a List of all the names of the <see cref="Adventurer"/>
    /// </summary>
    /// <returns> A List of all the names of the <see cref="Adventurer"/> </returns>
    public static List<string> GetAdventurersNames()
    {
        List<Adventurer> adventurers = MGMT_Xml.GetAdventurers();
        List<string> list = new List<string>();

        foreach (Adventurer adventurer in adventurers)
            list.Add(adventurer.name);
        
        return list;
    }



    /// <summary>
    /// Returns an <see cref="Adventurer"/> from its name
    /// </summary>
    /// <param name="name"> Name of the <see cref="Adventurer"/> </param>
    /// <returns> An Adventurer instance corresponding the parameter name </returns>
    public static Adventurer GetAdventurerFromName(string name)
    {
        List<Adventurer> adventurers = MGMT_Xml.GetAdventurers();

        foreach (Adventurer adventurer in adventurers)
        {
            if (adventurer.name == name)
                return adventurer;
        }

        return new Adventurer();
    }
}
