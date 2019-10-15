using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MGMT_EquipmentUI : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> transforms = new List<GameObject>();




    public void PopulateEquipmentUI(Adventurer adventurer)
    {
        GameObject newObj;

        DeleteEquipmentUI();
        foreach(Equipment equipment in adventurer.equipments)
        {
            newObj = (GameObject)Instantiate(prefab, transform);

            Transform partUpper = newObj.transform.GetChild(0);
            Transform partLower = newObj.transform.GetChild(1);


            // Upper Part
            // Background color
            partUpper.GetComponent<Image>().color = adventurer.color;

            Debug.Log("Equipments/Equipment_" + equipment.name);
            // Foreground equipment
            partUpper.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Equipments/Equipment_" + equipment.name);
            if (partUpper.transform.GetChild(0).GetComponent<Image>().sprite == null)
                partUpper.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DEFAULT");


            // Lower Part
            // Name
            partLower.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.name;
            // Description
            partLower.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.description;


            Debug.Log(adventurer.color);
            transforms.Add(newObj);
        }
    }




    private void DeleteEquipmentUI()
    {
        foreach (GameObject transform in transforms)
            Destroy(transform.gameObject, 0);
    }
}
