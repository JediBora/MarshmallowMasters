using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    //Used to check on marshmallow count, allowing or denying access to the marshmallow roasting mini game
    public LoadAndSave loadNSave;

    public GameObject difficultyCanvas;

    //0 = Save Your Sanwich
    //1 = Canoe Boo Boo
    //2 = Fishing Fishers
    //3 = Shoo Shoo Mosquito
    //4 = Flashlight B' Brokey
    //5 = Marshmallow Masters
    public int miniGameToLoad;


    private void OnTriggerEnter(Collider other)
    {
        ////Minigames

        if (other.tag == "SandwichC")
        {
            //Add Save your Sandwich Scene
            loadNSave.savedData.levelToLoadName = "SaveSam";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Save your Sandwich interaction");
        }

        if (other.tag == "CanoeC")
        {
            //Add Canoe Boo Boo Scene
            loadNSave.savedData.levelToLoadName = "CanoeBooBoo";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Canoe Boo Boo interaction");
        }

        if (other.tag == "FishingC")
        {
            //Add Fishing Fishers Scene
            loadNSave.savedData.levelToLoadName = "FishingFishers";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Fishing Fishers interaction");
        }

        if (other.tag == "MosquitoC")
        { loadNSave.savedData.levelToLoadName = "FishingFishers";

            loadNSave.RewriteSaveFile();
            miniGameToLoad = 3;
            difficultyCanvas.SetActive(true);

            //Add Shoo Shoo Mosquito Scene
            //SceneManager.LoadScene("ShooShooMosquitoTest");
            print("Shoo Shoo Mosquito interaction");
        }

        if (other.tag == "FlashlightC")
        {
            miniGameToLoad = 4;
            difficultyCanvas.SetActive(true);

            //Add Flashlight B'Brokey Scene
            //SceneManager.LoadScene("FlashlightBBrokey");
            print("Flashlight B'Brokey interaction");
        }

        if (other.tag == "MarshmallowC" && loadNSave.savedData.marshmallows > 0)
        {
            //Add Marshmallow Masters Scene
            loadNSave.savedData.levelToLoadName = "MarshmallowRoasting";

            loadNSave.RewriteSaveFile();

            SceneManager.LoadScene("LoadingScreen");
            print("Marshmallow Masters interaction");
        }

        else if (other.tag == "MarshmallowC" && loadNSave.savedData.marshmallows <= 0)
        {
            Debug.Log("You don't have neough shmellows scrub.");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SandwichC" || other.tag == "CanoeC" || other.tag == "FlashlightC" || other.tag == "FishingC" || other.tag == "MosquitoC")

            difficultyCanvas.SetActive(false);


    }

    //0 = Save Your Sanwich
    //1 = Canoe Boo Boo
    //2 = Fishing Fishers
    //3 = Shoo Shoo Mosquito
    //4 = Flashlight B' Brokey
    //5 = Marshmallow Masters
    public void LoadCorrespondingScene()
    {
        

             if (miniGameToLoad == 0)
        {
            loadNSave.savedData.levelToLoadName = "SaveSam";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 1)
        {
            loadNSave.savedData.levelToLoadName = "CanoeBooBoo";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 2)
        {
            loadNSave.savedData.levelToLoadName = "FishingFishers";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 3)
        {
            loadNSave.savedData.levelToLoadName = "ShooShooMosquitoTest";

            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 4)
        {
            loadNSave.savedData.levelToLoadName = "FlashlightBBrokey";
            loadNSave.RewriteSaveFile();
        }
        else if (miniGameToLoad == 5)
        {
            loadNSave.savedData.levelToLoadName = "MarshmallowRoasting";
            loadNSave.RewriteSaveFile();
        }

        SceneManager.LoadScene("LoadingScreen");
    }

}
