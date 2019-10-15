using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_KnightsShield : Equipment
{
    protected override string DEFAULT_NAME { get { return "Knight's Shield"; } }
    protected override string DEFAULT_DESCRIPTION { get { return "Adds 3 HPs"; } }
    protected override bool DEFAULT_ACTIVE { get { return true; } }


    /// <summary>
    /// Default constructor of the class <see cref="Equipment_KnightsShield"/>
    /// </summary>
    public Equipment_KnightsShield() : base() { }


    /// <summary>
    /// The effect actions of this <see cref="Equipment_KnightsShield"/>
    /// </summary>
    /// <param name="game"> Reference to the current Game </param>
    public override void Effect(Game game)
    {
        AddHP(game.adventurer, 3);
    }
}
