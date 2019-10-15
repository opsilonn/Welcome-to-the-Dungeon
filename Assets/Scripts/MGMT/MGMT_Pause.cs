using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGMT_Pause : MonoBehaviour
{
    public Transform container;


    // Start is called before the first frame update
    void Start()
    {
        MGMT.resume = false;
        container.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        switch (MGMT.pause)
        {
            case true:
                if (Input.GetButtonDown("Cancel"))
                    SetPause(false);
                break;

            case false:
                if (Input.GetButtonDown("Cancel") && !MGMT.resume)
                    SetPause(true);
                break;
        }
    }


    /// <summary>
    /// Sets (or not) the Pause Canvas
    /// </summary>
    /// <param name="value"> Whether or not to display the Pause Canvas </param>
    public void SetPause(bool value)
    {
        MGMT.pause = value;
        container.gameObject.SetActive(value);

    }
}
