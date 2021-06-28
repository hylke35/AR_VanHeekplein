using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    private Pose placemenetPose;
    
     public new Transform transform;

    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "MainMenu")
        {
            placemenetPose.position.z += 0.4f;
            placemenetPose.position.y -= 0.09f;
        }

        if(sceneName == "MapScene")
        {
            placemenetPose.position.z += 0.4f;
            placemenetPose.position.y -= 0.01f;
            
            
        }
        Instantiate(objectToPlace, placemenetPose.position, transform.rotation);
    }


    
}
