using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Adventurer : MonoBehaviour
{
    public Image imageAdventurer;


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
    public GameObject prefab;
    private List<GameObject> equipments = new List<GameObject>();

    /// <summary>
    /// Creates a list of object representing the inventory of a given Adventurer
    /// </summary>
    /// <param name="adventurer"> Adventurer of which we want to display the inventory </param>
    public void PopulateEquipmentUI(Adventurer adventurer)
    {
        GameObject newEquipment;

        DeleteEquipmentUI();
        foreach (Equipment equipment in adventurer.equipments)
        {
            newEquipment = (GameObject)Instantiate(prefab, content.transform);

            Transform partUpper = newEquipment.transform.GetChild(0);
            Transform partLower = newEquipment.transform.GetChild(1);


            // Upper Part
            // Background color
            partUpper.GetComponent<Image>().color = adventurer.color;

            // Foreground equipment
            partUpper.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Equipments/Equipment_" + equipment.name);
            if (partUpper.transform.GetChild(0).GetComponent<Image>().sprite == null)
                partUpper.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DEFAULT");


            // Lower Part
            // Name
            partLower.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.name;
            // Description
            partLower.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.description;

            equipments.Add(newEquipment);
        }
    }


    /// <summary>
    /// Erase all the UI element representing an adventurer's inventory
    /// </summary>
    private void DeleteEquipmentUI()
    {
        foreach (GameObject transform in equipments)
            Destroy(transform.gameObject, 0);
    }
}