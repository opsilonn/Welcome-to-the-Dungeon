using System.Collections.Generic;
using UnityEngine;

public class Main_Game : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;

    public Game game = new Game();


    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(MGMT_Adventurer.GetAdventurersNames());
        dropdown.onValueChanged.AddListener(delegate { CreateTable(); });

        game.players.Add( new Player() );
        game.players.Add(new Player("Daenerys", 2, 1));
        game.players.Add(new Player("Cersei", 0, 2));
        game.players.Add(new Player("Adam", 1, 2));

        CreateTable();
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




    List<Adventurer> adventurers = MGMT_Xml.GetAdventurers();
    Adventurer currentAdventurer
    {
        get{ return adventurers[dropdown.value]; }
    }
}
