using System.Collections;
using TMPro;
using UnityEngine;

public class FPS_Counter : MonoBehaviour
{
    public TextMeshProUGUI text;


    /// <summary>
    /// Updates the FPS Counter
    /// </summary>
    private IEnumerator FPSCounter()
    {
        while( true )
        {
            text.SetText( (1 / Time.deltaTime).ToString("0.0") + " FPS");
            yield return new WaitForSeconds( 1 );
        }
    }




    void Start()
    {
        StartCoroutine(FPSCounter());
    }
} 