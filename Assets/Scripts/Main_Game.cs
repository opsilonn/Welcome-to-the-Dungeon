using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main_Game : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;
    public MGMT_AdventurerUI MGMT_AUI;
    public MGMT_EquipmentUI MGMT_EUI;
    public Game game = new Game();


    void Start()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(MGMT_Adventurer.GetAdventurersNames());
        dropdown.onValueChanged.AddListener(delegate
        {
            SetCurrentAdventurer();
            CreateTable();
        });

        game.players.Add( new Player() );
        game.players.Add(new Player("Daenerys", 2, 1));
        game.players.Add(new Player("Cersei", 0, 2));
        game.players.Add(new Player("Adam", 1, 2));
        game.currentPlayer = game.players[0];

        SetCurrentAdventurer();
        CreateTable();

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
    }



    public Transform container;
    public Transform template;
    private float templateHeight = -50f;

    private static readonly string TEXT_EQUIPMENT = "Template_Equipment";
    private static readonly string TEXT_DESCRIPTION = "Template_Description";

    private List<Transform> transforms = new List<Transform>();



    /// <summary>
    /// Sets the text accordingly to the equipment of the current adventurer
    /// </summary>
    private void CreateTable()
    {
        template.gameObject.SetActive(true);
        DeleteTable();
        transforms = new List<Transform>();

        if (currentAdventurer.equipments.Count == 0)
        {
            container.Find("Template").Find(TEXT_EQUIPMENT).GetComponent<TMPro.TextMeshProUGUI>().text = "No equipment !!";
            container.Find("Template").Find(TEXT_DESCRIPTION).GetComponent<TMPro.TextMeshProUGUI>().text = "...Thus, no description";
        }
        else
        {
            int i = 1;
            foreach (Equipment equipment in currentAdventurer.equipments)
                CreateTableRank(equipment, i++);

            template.gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Sets the text of a given rank accordingly to the equipment of the current adventurer
    /// </summary>
    private void CreateTableRank(Equipment equipment, int rang)
    {
        Transform tableTransform = Instantiate(template, container);
        RectTransform tableRectTransform = tableTransform.GetComponent<RectTransform>();
        tableRectTransform.anchoredPosition = new Vector2(0, templateHeight * rang);

        tableTransform.Find(TEXT_EQUIPMENT).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.name;
        tableTransform.Find(TEXT_DESCRIPTION).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.description;

        transforms.Add(tableTransform);
    }


    private void DeleteTable()
    {
        foreach (Transform transform in transforms)
            Destroy(transform.gameObject, 0);
    }




    Adventurer currentAdventurer
    {
        get{ return MGMT_Xml.GetAdventurers()[dropdown.value]; }
    }


    public void SetCurrentAdventurer()
    {
        game.adventurer = MGMT_Xml.GetAdventurers()[dropdown.value];
        MGMT_AUI.setUI(game.adventurer);
        MGMT_EUI.PopulateEquipmentUI(currentAdventurer);
    }
}
