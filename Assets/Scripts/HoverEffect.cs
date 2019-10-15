using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float augmentation;

    /// <summary>
    /// Agrandit l'objet quand la souris le survole
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale += new Vector3(augmentation, augmentation, 0);
    }


    /// <summary>
    /// Rétrécit l'objet quand la souris arrête de le survoler
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale -= new Vector3(augmentation, augmentation, 0);
    }
}
