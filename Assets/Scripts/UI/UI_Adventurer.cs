using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Adventurer : MonoBehaviour
{
    public Image imageAdventurer;
    public UI_Equipment UI_equipment;


    public void setAdventurer(Adventurer adventurer)
    {
        setImage(adventurer);
        PopulateEquipmentUI(adventurer);
    }


    /// <summary>
    /// Sets the image representing an adventurer
    /// </summary>
    /// <param name="adventurer"> Adventurer of which we want to display an image </param>
    public void setImage(Adventurer adventurer)
    {
        imageAdventurer.sprite = Resources.Load<Sprite>("Adventurers/Adventurer_" + adventurer.name);

        if(imageAdventurer.sprite == null)
            imageAdventurer.sprite = Resources.Load<Sprite>("DEFAULT");
    }






    public GameObject content;
    private List<UI_Equipment> equipments = new List<UI_Equipment>();

    /// <summary>
    /// Creates a list of object representing the inventory of a given Adventurer
    /// </summary>
    /// <param name="adventurer"> Adventurer of which we want to display the inventory </param>
    public void PopulateEquipmentUI(Adventurer adventurer)
    {
        DeleteEquipmentUI();


        foreach (Equipment equipment in adventurer.equipments)
        {
            // UI_Equipment UI_e = Instantiate<UI_Equipment>(UI_equipment);
            UI_equipment.Init(adventurer, equipment, content);
            //equipments.Add( UI_Equipment.Init(adventurer, equipment, content) );
            
        // UI_equipment.setEquipmentUI(adventurer, equipment, content));
        }
    }


    /// <summary>
    /// Erase all the UI element representing an adventurer's inventory
    /// </summary>
    private void DeleteEquipmentUI()
    {
        foreach (UI_Equipment equipment in equipments)
            Destroy(equipment.gameObject, 0);
    }
}