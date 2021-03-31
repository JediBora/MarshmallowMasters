using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string levelToLoad;
    public Image progressBar;

    public LoadAndSave loadAndSave;



    // Start is called before the first frame update
    void Start()
    {
        levelToLoad = loadAndSave.savedData.levelToLoadName;

        //Start async operation
        StartCoroutine(LoadASyncOperation());

    }

    IEnumerator LoadASyncOperation()
    {
        //Create ASync operation
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(levelToLoad);

        while (gameLevel.progress < 1)
        {
            //Take the progress bar fill = async operation progress
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();



        }

        //When finisehd, load the game scene


        yield return new WaitForEndOfFrame();

    }



}
