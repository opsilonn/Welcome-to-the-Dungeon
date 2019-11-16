using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UI_Equipment : MonoBehaviour
{
    public GameObject prefab;

    private Equipment equipment;


    /// <summary>
    /// Sets a UI element containing the info of an Equipment piece
    /// </summary>
    /// <param name="adventurer"> Adventurer of which we dispaly an equipment piece </param>
    /// <param name="equipment"> Piece of equipment to display </param>
    /// <param name="content"> Location where to display the content </param>
    /// <returns> the UI element containing the info of an Equipment piece</returns>
    public void Init(Adventurer adventurer, Equipment equipment, GameObject content)
    {
        Debug.Log(prefab == null);
        Debug.Log(content == null);
        GameObject newEquipment = (GameObject)Instantiate(prefab, content.transform);

        Transform partUpper = newEquipment.transform.GetChild(0);
        Transform partLower = newEquipment.transform.GetChild(1);



        // Upper Part
        // Background color
        partUpper.GetComponent<Image>().color = adventurer.color;

        // Foreground equipment image
        partUpper.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Equipments/Equipment_" + equipment.name);
        if (partUpper.transform.GetChild(0).GetComponent<Image>().sprite == null)
            partUpper.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DEFAULT");


        // Lower Part
        // Name text
        partLower.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.name;

        // Description text
        partLower.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = equipment.description;


        // Display (or not) the Red cross image
        newEquipment.transform.GetChild(2).gameObject.SetActive(!equipment.active);
    }


    private void Update()
    {
        // If the equipment is NOT active, we display a red cross
        // newEquipment.transform.GetChild(2).gameObject.SetActive( !equipment.active );
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}