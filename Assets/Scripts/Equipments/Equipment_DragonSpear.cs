﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_DragonSpear : Equipment
{
    protected override string DEFAULT_NAME { get { return "Dragon Spear"; } }
    protected override string DEFAULT_DESCRIPTION { get { return "Ignore the Dragon"; } }
    protected override bool DEFAULT_ACTIVE { get { return true; } }


    /// <summary>
    /// Default constructor of the class <see cref="Equipment_DragonSpear"/>
    /// </summary>
    public Equipment_DragonSpear() : base() { }


    public override void Effect(Game game)
    {
        List<int> list = new List<int>( new int[] { 8 } );
        IgnoreMonsters(game.deck[1], list);
    }
}