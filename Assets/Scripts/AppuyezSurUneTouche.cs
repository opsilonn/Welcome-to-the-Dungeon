using UnityEngine;


public class AppuyezSurUneTouche : MonoBehaviour
{
    public GameObject toClose;
    public GameObject toOpen;


    void Update()
    {
        if (Input.anyKey)
        {
            toOpen.SetActive(true);
            toClose.SetActive(false);
        }
    }
}