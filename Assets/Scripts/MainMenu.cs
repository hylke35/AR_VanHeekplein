using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Move to AR Scene 
    public void LaunchAR()
    {

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    //Move to Map Scene
    public void MapScene()
    {

        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
