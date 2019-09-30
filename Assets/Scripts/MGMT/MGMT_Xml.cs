using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public static class MGMT_Xml
{
    public static string path = @"assets\Saved Data\";

    private static Dictionary<int, string> dictionaryEquipment;


    /// <summary>
    /// Displays the values contained in the dictionaryEquipment's variable
    /// </summary>
    public static void PrintDictionnary()
    {
        dictionaryEquipment = GetEquipment();

        foreach (KeyValuePair<int, string> line in dictionaryEquipment)
            Debug.Log("Key = " + line.Key + " - Value = " + line.Value);
    }




    /// <summary>
    /// Returns a list of all the Default <see cref="Monster"/>
    /// </summary>
    /// <returns> A list of all the Default <see cref="Monster"/> </returns>
    public static List<Monster> GetDefaultMonsters()
    {
        string file = path + "Monsters.xml";

        List<Monster> monsters = new List<Monster>();

        XmlReader xmlReader = XmlReader.Create(file);
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "monster")
            {
                if (xmlReader.HasAttributes)
                    monsters.Add(new Monster(
                        int.Parse(xmlReader.GetAttribute("ID")),
                        xmlReader.GetAttribute("name"),
                        int.Parse(xmlReader.GetAttribute("power"))));
            }
        }

        return monsters;
    }





    /// <summary>
    /// Returns a list of all the <see cref="Adventurer"/>
    /// </summary>
    /// <returns> A list of all the <see cref="Adventurer"/> </returns>
    public static List<Adventurer> GetAdventurers()
    {
        dictionaryEquipment = GetEquipment();
        DirectoryInfo d = new DirectoryInfo(@"assets\Saved Data");
        FileInfo[] files = d.GetFiles("Adventurer*.xml");


        List<Adventurer> adventurers = new List<Adventurer>();


        // Iterating through all the xml Files
        foreach(FileInfo file in files)
            adventurers.Add( GetAdventurer(path + file.Name) );

        return adventurers;
    }




    /// <summary>
    /// Returns an <see cref="Adventurer"/>
    /// </summary>
    /// <param name="fullPath"> Path of the xml file describing the <see cref="Adventurer"/> </param>
    /// <returns> An <see cref="Adventurer"/> </returns>
    public static Adventurer GetAdventurer(string fullPath)
    {
        // Setting the default values
        string name = "John DOE";
        int hp = 3;
        List<Equipment> equipments = new List<Equipment>();


        // Reading the file, changing the values if said to
        XmlReader xmlReader = XmlReader.Create(fullPath);
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                if (xmlReader.Name == "adventurer" && xmlReader.HasAttributes)
                {
                    name = xmlReader.GetAttribute("name");
                    hp = int.Parse(xmlReader.GetAttribute("hp"));
                }
                if (xmlReader.Name == "equipment" && xmlReader.HasAttributes)
                {
                    int ID = int.Parse(xmlReader.GetAttribute("ID"));
                    if(dictionaryEquipment.ContainsKey(ID))
                        equipments.Add((Equipment)CreateInstance.MagicallyCreateInstance(dictionaryEquipment[ID]));
                }
            }
        }

        return new Adventurer(name, hp, equipments);
    }




    /// <summary>
    /// Returns a list of all the available <see cref="Equipment"/>
    /// </summary>
    /// <returns> A Dictionary containing the ID and the corresponding <see cref="Equipment"/>'s Class name </returns>
    public static Dictionary<int, string> GetEquipment()
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        string filePath = path + "Equipment.xml";
        XmlReader xmlReader = XmlReader.Create(filePath);
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "equipment")
            {
                if (xmlReader.HasAttributes)
                    dictionary.Add(int.Parse(xmlReader.GetAttribute("ID")), xmlReader.GetAttribute("className"));
            }
        }



        return dictionary;
    }
}