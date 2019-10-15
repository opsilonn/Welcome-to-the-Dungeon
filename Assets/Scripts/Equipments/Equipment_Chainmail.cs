using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_Chainmail : Equipment
{
    protected override string DEFAULT_NAME { get { return "Chainmail"; } }
    protected override string DEFAULT_DESCRIPTION { get { return "Adds 4 HPs"; } }
    protected override bool DEFAULT_ACTIVE { get { return true; } }


    /// <summary>
    /// Default constructor of the class <see cref="Equipment_Chainmail"/>
    /// </summary>
    public Equipment_Chainmail() : base() { }


    /// <summary>
    /// The effect actions of this <see cref="Equipment_Chainmail"/>
    /// </summary>
    /// <param name="game"> Reference to the current Game </param>
    public override void Effect(Game game)
    {
        int hp = 5;
        AddHP(game.adventurer, hp);
    }
}
