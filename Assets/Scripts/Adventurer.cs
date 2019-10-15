using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer
{
    private string _name;
    private int _hp;
    private List<Equipment> _equipments;
    private Color32 _color;

    private readonly Color32 DEFAULT_COLOR = new Color32(150, 150, 150, 255);
    private readonly string DEFAULT_NAME = "Adventurer";
    private readonly int DEFAULT_HP = 3;


    /// <summary>
    /// Default constructor of the class <see cref="Adventurer"/>
    /// </summary>
    public Adventurer()
    {
        name = DEFAULT_NAME;
        hp = DEFAULT_HP;
        equipments = new List<Equipment>();
        color = DEFAULT_COLOR;
    }


    /// <summary>
    /// Complete constructor of the class <see cref="Adventurer"/>
    /// </summary>
    /// <param name="name"> name of the instance </param>
    /// <param name="hp"> number of Health's Points of the instance</param>
    /// <param name="equipments"> List of all the equipments </param>
    /// <param name="color"> Color32 representing the instance </param>
    public Adventurer(string name, int hp, List<Equipment> equipments, Color color)
    {
        this.name = name;
        this.hp = hp;
        this.equipments = equipments;
        this.color = color;
    }


    /// <summary>
    /// Textual representation of the instance displayed in the Debug.Log
    /// </summary>
    public void Display()
    {
        Debug.Log("<b>Adventurer</b>");
        Debug.Log("Name : " + name);
        Debug.Log("HP : " + hp);
        if(equipments.Count == 0)
        {
            Debug.Log("Equipment : none");
        }
        else
        {
            Debug.Log("Equipment : " + equipments.Count);
            foreach (Equipment equipment in equipments)
                equipment.Display();
        }
        Debug.Log("");
    }




    /// <summary>
    /// Returns whether the instance is alive or not (pv under 0)
    /// </summary>
    /// <returns> True if the instance is dead, False otherwise </returns>
    public bool isDead()
    {
        return hp <= 0;
    }



    // PARAMETERS
    public int hp
    {
        get { return _hp; }
        set
        {
            if (value < 0)
                _hp = 0;
            else
                _hp = value;
        }
    }
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public List<Equipment> equipments
    {
        get { return _equipments; }
        set { _equipments = value; }
    }
    public Color color
    {
        get { return _color; }
        set { _color = value; }
    }
}