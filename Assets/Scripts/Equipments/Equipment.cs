using System.Collections.Generic;
using UnityEngine;


public abstract class Equipment
{
    private string _name;
    private string _description;
    private bool _active;

    protected abstract string DEFAULT_NAME { get; }
    protected abstract string DEFAULT_DESCRIPTION { get; }
    protected abstract bool DEFAULT_ACTIVE { get; }


    /// <summary>
    /// Default constructor of the class <see cref="Equipment"/>
    /// </summary>
    public Equipment()
    {
        name = DEFAULT_NAME;
        description = DEFAULT_DESCRIPTION;
        active = DEFAULT_ACTIVE;
    }


    /// <summary>
    /// Complete constructor of the class <see cref="Equipment"/>
    /// </summary>
    /// <param name="name"> name of the instance </param>
    /// <param name="description"> description of the instance </param>
    /// <param name="active"> if the instance can be used or not </param>
    public Equipment(string name, string description, bool active)
    {
        this.name = name;
        this.description = description;
        this.active = active;
    }


    public void Display()
    {
        Debug.Log("  Name : " + name);
        Debug.Log("  Description : " + description);
        Debug.Log("  Active : " + active);
        Debug.Log("");
    }




    /// <summary>
    /// Effect of the instance
    /// </summary>
    public abstract void Effect(Game game);



    /// <summary>
    /// We add a given number of Health Points to the Adventurer
    /// </summary>
    /// <param name="adventurer"> The adventurer that is being played </param>
    /// <param name="hp"> The amount of Health Point to add </param>
    protected void AddHP(Adventurer adventurer, int hp)
    {
        adventurer.hp += hp;
    }


    /// <summary>
    /// Skips the <see cref="Monster"/> with a power higher than a given threshold
    /// </summary>
    /// <param name="currentMonster"> The <see cref="Monster"/> currently facing the <see cref="Player"/> </param>
    /// <param name="threshold"> Level at which monsters with a higher power are ignored </param>
    protected void IgnoreUpper(Monster currentMonster, int threshold)
    {
        if (currentMonster.power >= threshold)
        {
            // passer le monstre
        }
    }


    /// <summary>
    /// Skips the <see cref="Monster"/> with a power lower than a given threshold
    /// </summary>
    /// <param name="currentMonster"> The <see cref="Monster"/> currently facing the <see cref="Player"/> </param>
    /// <param name="threshold"> Level at which monsters with a lower power are ignored </param>
    protected void IgnoreLower(Monster currentMonster, int threshold)
    {
        if (currentMonster.power <= threshold)
        {
            // passer le monstre
        }
    }


    /// <summary>
    /// Skips the <see cref="Monster"/> with a power contained in a list
    /// </summary>
    /// <param name="currentMonster"> The <see cref="Monster"/> currently facing the <see cref="Player"/> </param>
    /// <param name="powersIgnored"> List of all the power levels that are ignored </param>
    protected void IgnoreLevels(Monster currentMonster, List<int> powersIgnored)
    {
        if (powersIgnored.Contains(currentMonster.power))
        {
            // passer le monstre
        }
    }


    /// <summary>
    /// Skips the <see cref="Monster"/> of a given type
    /// </summary>
    /// <param name="currentMonster"> The <see cref="Monster"/> currently facing the <see cref="Player"/> </param>
    /// <param name="monstersIgnored"> List of all the monsters (using their IDs) that are ignored </param>
    protected void IgnoreMonsters(Monster currentMonster, List<int> monstersIgnored)
    {
        if (monstersIgnored.Contains(currentMonster.ID))
        {
            // passer le monstre
        }
    }


    /// <summary>
    /// Sets a race of <see cref="Monster"/> to be ignored
    /// </summary>
    /// <returns> The type of <see cref="Monster"/> to be ignored (using their IDs) </returns>
    protected int SetVorpal()
    {
        // A coder
        return 1;
    }


    /// <summary>
    /// Skips a <see cref="Monster"/> after absorbing its power
    /// </summary>
    /// <param name="currentMonster"> The <see cref="Monster"/> currently facing the <see cref="Player"/> </param>
    /// <param name="IDs"> List of all the monsters (using their IDs) that are absorbed </param>
    protected void AbsorbMonster_ID(Adventurer adventurer, Monster currentMonster, List<int> IDs)
    {
        if (IDs.Contains(currentMonster.ID))
        {
            AddHP(adventurer, currentMonster.power);
            // passer le monstre
        }
    }




    // PARAMETERS
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string description
    {
        get { return _description; }
        set { _description = value; }
    }
    public bool active
    {
        get { return _active; }
        set { _active = value; }
    }
}
