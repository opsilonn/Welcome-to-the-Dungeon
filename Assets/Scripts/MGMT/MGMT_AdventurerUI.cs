using UnityEngine;
using UnityEngine.UI;


public class MGMT_AdventurerUI : MonoBehaviour
{
    public Image imageAdventurer;



    public void setUI(Adventurer adventurer)
    {
        imageAdventurer.sprite = Resources.Load<Sprite>("Adventurers/Adventurer_" + adventurer.name);

        if(imageAdventurer.sprite == null)
            imageAdventurer.sprite = Resources.Load<Sprite>("DEFAULT");
    }
}