using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnClick : MonoBehaviour
{
    // this code enables buttons to load new scenes
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}