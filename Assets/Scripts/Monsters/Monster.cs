using UnityEngine;


public class Monster
{
    private int _ID;
    private string _name;
    private int _power;

    private readonly int DEFAULT_ID = 0;
    private readonly string DEFAULT_NAME = "mob";
    private readonly int DEFAULT_POWER = 1;


    /// <summary>
    /// Default constructor of the class <see cref="Monster"/>
    /// </summary>
    public Monster()
    {
        ID = DEFAULT_ID;
        name = DEFAULT_NAME;
        power = DEFAULT_POWER;
    }


    /// <summary>
    /// Complete constructor of the class <see cref="Monster"/>
    /// </summary>
    /// <param name="ID"> ID of the instance </param>
    /// <param name="name"> name of the instance </param>
    /// <param name="power"> numerical representation of the power of the instance</param>
    public Monster(int ID, string name, int power)
    {
        this.ID = ID;
        this.name = name;
        this.power = power;
    }


    /// <summary>
    /// Textual representation of the instance displayed in the Debug.Log
    /// </summary>
    public void Display()
    {
        Debug.Log("<b>Monster</b>");
        Debug.Log("ID : " + ID);
        Debug.Log("Name : " + name);
        Debug.Log("Power : " + power);
        Debug.Log("");
    }




    // PARAMETERS
    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int power
    {
        get { return _power; }
        set
        {
            if (value < 0)
                _power = 0;
            else
                _power = value;
        }
    }
}
