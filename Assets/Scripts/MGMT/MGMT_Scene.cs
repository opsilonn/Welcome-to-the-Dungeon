using UnityEngine;
using UnityEngine.SceneManagement;


public class MGMT_Scene : MonoBehaviour
{
    /// <summary>
    /// Launches a scene
    /// </summary>
    /// <param name="scene"> Name of the scene to launch </param>
    public void LaunchScene(string scene)
    {
        SceneManager.LoadScene( scene );
    }


    /// <summary>
    /// Ends the software
    /// </summary>
    public void LeaveSoftware()
    {
        Application.Quit();
    }
}