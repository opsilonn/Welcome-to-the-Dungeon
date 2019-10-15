using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_PlateArmor : Equipment
{
    protected override string DEFAULT_NAME { get { return "Plate Armor"; } }
    protected override string DEFAULT_DESCRIPTION { get { return "Adds 5 HPs"; } }
    protected override bool DEFAULT_ACTIVE { get { return true; } }


    /// <summary>
    /// Default constructor of the class <see cref="Equipment_PlateArmor"/>
    /// </summary>
    public Equipment_PlateArmor() : base() { }


    /// <summary>
    /// The effect actions of this <see cref="Equipment_PlateArmor"/>
    /// </summary>
    /// <param name="game"> Reference to the current Game </param>
    public override void Effect(Game game)
    {
        AddHP(game.adventurer, 5);
    }
}