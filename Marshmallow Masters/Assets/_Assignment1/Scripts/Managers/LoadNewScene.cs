using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour
{
    public void LoadSceneByInt(int p_sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(p_sceneIndex);
    }
    public void LoadSceneByString(string p_sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(p_sceneName);
    }

    public void ReloadThisScene()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
