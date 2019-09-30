using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private System.Guid _ID;
    private string _pseudonym;
    private bool _plays;
    private int _points;
    private int _hp;

    private static readonly string DEFAULT_PSEUDONYM = "John Doe";
    private static readonly bool DEFAULT_PLAYS = true;
    private static readonly int DEFAULT_POINTS = 0;
    private static readonly int DEFAULT_HP = 2;


    /// <summary>
    /// Default constructor of the class <see cref="Player"/>
    /// </summary>
    public Player()
    {
        ID = System.Guid.NewGuid();
        pseudonym = DEFAULT_PSEUDONYM;
        plays = DEFAULT_PLAYS;
        points = DEFAULT_POINTS;
        hp = DEFAULT_HP;
    }


    /// <summary>
    /// Advanced constructor of the class <see cref="Player"/>
    /// </summary>
    /// <param name="pseudonym"> Pseudonym of the instance </param>
    /// <param name="points"> Points won by the instance </param>
    /// <param name="hp"> Health Points left of the instance </param>
    public Player(string pseudonym, int points, int hp)
    {
        ID = System.Guid.NewGuid();
        this.pseudonym = pseudonym;
        plays = DEFAULT_PLAYS;
        this.points = points;
        this.hp = hp;
    }


    /// <summary>
    /// Complete constructor of the class <see cref="Player"/>
    /// </summary>
    /// <param name="ID"> ID of the instance </param>
    /// <param name="pseudonym"> Pseudonym of the instance </param>
    /// <param name="points"> Points won by the instance </param>
    /// <param name="hp"> Health Points left of the instance </param>
    public Player(System.Guid ID, string pseudonym, bool plays, int points, int hp)
    {
        this.ID = ID;
        this.pseudonym = pseudonym;
        this.plays = plays;
        this.points = points;
        this.hp = hp;
    }



    // Parameters
    public System.Guid ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    public string pseudonym
    {
        get { return _pseudonym; }
        set { _pseudonym = value; }
    }
    public bool plays
    {
        get { return _plays; }
        set { _plays = value; }
    }
    public int points
    {
        get { return _points; }
        set { _points = value; }
    }
    public int hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
}