using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverEffectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;
    public float augmentation;

    /// <summary>
    /// Agrandit l'objet quand la souris le survole
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.gameObject.transform.localScale += new Vector3(augmentation, augmentation, 0);
    }



    /// <summary>
    /// Rétrécit l'objet quand la souris arrête de le survoler
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        text.gameObject.transform.localScale -= new Vector3(augmentation, augmentation, 0);
    }
}