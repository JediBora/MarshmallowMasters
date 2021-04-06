using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameModified : MonoBehaviour
{

    public LoadAndSave loadAndSave;
    public GameController gameController;
    public FlashlightDifficultyController flashDifController;

    public GameObject endCanvasThing;

    public Scene currentScene;

    public Text shmellowCount;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (gameController)
        
            if (gameController.outOfForest)
            {
                endCanvasThing.SetActive(true);


                if (flashDifController.difficultyOne)
                    shmellowCount.text = "+2";
                else if (flashDifController.difficultyTwo)
                    shmellowCount.text = "+4";
                else if (flashDifController.difficultyThree)
                    shmellowCount.text = "+6";

            }
            else if (gameController.wentInsane)
            {
                endCanvasThing.SetActive(true);
                shmellowCount.text = "+0";
            }
               
        }



        public void BackToCamp()
        {
            loadAndSave.savedData.levelToLoadName = "UpdatedCampOverworld";

            loadAndSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");


        }


    }
