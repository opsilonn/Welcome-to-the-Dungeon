using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private Adventurer _adventurer;
    private List<Player> _players;
    private List<Monster> _deck;
    private List<Monster> _dungeon;
    private List<Monster> _discard;
    private int _pointsRequired;
    private int _defaultHP;

    private static readonly int DEFAULT_POINTS = 2;
    private static readonly int DEFAULT_HP = 2;



    /// <summary>
    /// Default constructor of the class <see cref="Game"/>
    /// </summary>
    public Game()
    {
        adventurer = new Adventurer();
        players = new List<Player>();
        deck = new List<Monster>();
        dungeon = new List<Monster>();
        discard = new List<Monster>();
        pointsRequired = DEFAULT_POINTS;
        defaultHP = DEFAULT_HP;
    }



    /// <summary>
    /// Displays the Deck.
    /// </summary>
    /// <param name="index"> if 1, displays the Deck; if 2, displays the Dungeon; if 3, displays the Discard. </param>
    public void Display_List_Monsters(int index)
    {
        List<Monster> list = new List<Monster>();
        string name = "";


        if (index == 1) { list = deck; name = "deck"; }
        if (index == 2) { list = dungeon; name = "Dungeon"; }
        if (index == 3) { list = discard; name = "Discard"; }


        Debug.Log("<b>" + name + " : " + list.Count + "</b>");
        foreach (Monster monster in list)
            Debug.Log(monster.name + " - " + monster.power);


        Debug.Log("");
    }



    /// <summary>
    /// Empties the dungeon and the discard, the shuffles the deck
    /// </summary>
    public void ShuffleDeck()
    {
        // We add both the dungeon and the discard to the deck, and we empty them
        deck.AddRange(dungeon);
        deck.AddRange(discard);
        dungeon.Clear();
        discard.Clear();


        System.Random rng = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int index = rng.Next(n + 1);
            Monster monster = deck[index];
            deck[index] = deck[n];
            deck[n] = monster;
        }
    }




    // PARAMETERS
    public Adventurer adventurer
    {
        get { return _adventurer; }
        set { _adventurer = value; }
    }
    public List<Player> players
    {
        get { return _players; }
        set { _players = value; }
    }
    public List<Monster> deck
    {
        get { return _deck; }
        set { _deck = value; }
    }
    public List<Monster> dungeon
    {
        get { return _dungeon; }
        set { _dungeon = value; }
    }
    public List<Monster> discard
    {
        get { return _discard; }
        set { _discard = value; }
    }
    public int pointsRequired
    {
        get { return _pointsRequired; }
        set { _pointsRequired = value; }
    }
    public int defaultHP
    {
        get { return _defaultHP; }
        set { _defaultHP = value; }
    }
}
