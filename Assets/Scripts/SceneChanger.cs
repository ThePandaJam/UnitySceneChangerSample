using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void ChangeSceneTo(string sceneName)
    {
        //log that the desired scene is loading (optional, but good for debugging)
        Debug.Log($"{sceneName} loading...");
        /*Coroutines can execute across several frames, pause execution and
         return control to Unity when it's finished execution*/
        StartCoroutine (LoadAsyncScene(sceneName));
    }
    
    public IEnumerator LoadAsyncScene(string sceneName)
    {
        //The desired scene is loaded in the background while the current scene runs
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        //wait until the scene fully loads
        while(!asyncLoad.isDone){
            yield return null;
        }
        //once the desired scene is loaded, the execution of the code continues where it left off
    }
    
    
}

