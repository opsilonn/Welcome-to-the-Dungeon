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


    public override void Effect(Game game)
    {
        int hp = 5;
        AddHP(game.adventurer, hp);
    }
}