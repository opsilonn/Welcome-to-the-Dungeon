using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Main_Game : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdownAdventurers;
    public UI_Adventurer UI_adventurer;
    public Game game;
    public TextMeshProUGUI textNumberMonster;


    void Start()
    {
        // We set up the dropdown containing all the adventurer's names
        // We empty the dropdown
        dropdownAdventurers.ClearOptions();
        // We add all the adventurer's name
        dropdownAdventurers.AddOptions(MGMT_Adventurer.GetAdventurersNames());
        // When the value is changed, we display the corresponding adventurer's UI elements
        dropdownAdventurers.onValueChanged.AddListener(delegate
        {
            SetCurrentAdventurer();
        });


        // We manually add players to the game.
        game = new Game();
        game.players.Add( new Player() );
        game.players.Add(new Player("Daenerys", 2, 1));
        game.players.Add(new Player("Cersei", 0, 2));
        game.players.Add(new Player("Adam", 1, 2));
        game.currentPlayer = game.players[0];

        // Not implemented correctly yet...
        SetCurrentAdventurer();
        game.adventurer = MGMT_Xml.GetAdventurers()[0];

        /*
        do
        {
            foreach (Player player in game.players)
            {
                Debug.Log(player.pseudonym);
            }
        }
        while (game.KeepTurning());
        */
    }


    void Update()
    {
        // Debug.Log(game.currentPlayer.plays);

        // We display the number of monster(s) in the dungeon. If needed, we display at plural
        textNumberMonster.text = "Dungeon : " + game.dungeon.Count + " monster";
        if (game.dungeon.Count > 1)
            textNumberMonster.text += "s";
    }




    /// <summary>
    /// Changes the game's Adventurer and sets all the corresponding UI elements
    /// </summary>
    public void SetCurrentAdventurer()
    {
        game.adventurer = MGMT_Xml.GetAdventurers()[dropdownAdventurers.value];
        UI_adventurer.setAdventurer(game.adventurer);
    }
}