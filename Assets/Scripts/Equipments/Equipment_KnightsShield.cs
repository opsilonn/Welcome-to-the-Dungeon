using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_KnightsShield : Equipment
{
    protected override string DEFAULT_NAME { get { return "Knight's Shield"; } }
    protected override string DEFAULT_DESCRIPTION { get { return "Adds 3 HPs"; } }
    protected override bool DEFAULT_ACTIVE { get { return true; } }


    /// <summary>
    /// Default constructor of the class <see cref="Equipment_PlateArmor"/>
    /// </summary>
    public Equipment_KnightsShield() : base() { }


    /// <summary>
    /// The effect actions of this <see cref="Equipment_PlateArmor"/>
    /// </summary>
    /// <param name="game"></param>
    public override void Effect(Game game)
    {
        int hp = 3;
        AddHP(game.adventurer, hp);
    }
}
